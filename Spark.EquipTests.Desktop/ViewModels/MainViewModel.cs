using Spark.EquipTests.Desktop.Infrastructure;
using Spark.EquipTests.Desktop.Models;
using Spark.EquipTests.Desktop.Services;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;

namespace Spark.EquipTests.Desktop.ViewModels
{
    /// <summary>
    /// Главная ViewModel
    /// </summary>
    public class MainViewModel : BaseViewModel
    {
        #region Services
        /// <summary>
        /// Сервис для доступа к таблице 'Test'
        /// </summary>
        private readonly IEquipTestDataProvider<Test> equipTestDataProvider;
        /// <summary>
        /// Сервис для доступа к таблице 'Parameter'
        /// </summary>
        private readonly IEquipTestDataProvider<Parameter> paramTestDataProvider;
        #endregion

        #region Bindable Properties
        /// <summary>
        /// Выбранный тест
        /// </summary>
        private TestViewModel? selectedTest;
        public TestViewModel? SelectedTest
        {
            get => selectedTest;
            set
            {
                if (selectedTest != value)
                {
                    selectedTest = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Список тестов
        /// </summary>
        private ObservableCollection<TestViewModel>? equipTests;
        public ObservableCollection<TestViewModel>? EquipTests
        {
            get => equipTests;
            set
            {
                if (equipTests != value)
                {
                    equipTests = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Выбранный параметр
        /// </summary>
        private ParameterViewModel? selectedParameter;
        public ParameterViewModel? SelectedParameter
        {
            get=> selectedParameter;
            set
            {
                if (selectedParameter != value)
                {
                    selectedParameter = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Список параметров
        /// </summary>
        private ObservableCollection<ParameterViewModel>? parameterTests;
        public ObservableCollection<ParameterViewModel>? ParameterTests
        {
            get => parameterTests;
            set
            {
                if(parameterTests != value)
                {
                    parameterTests = value;
                    OnPropertyChanged();
                }
            }

        }
        #endregion

        #region Commands
        /// <summary>
        /// Добавить тест
        /// </summary>
        private RelayCommand addTest;
        public RelayCommand AddTest
        {
            get
            {
                return addTest ?? (addTest = new RelayCommand(
                    _=>
                    {
                        var newTest = new TestViewModel(new Test() { Blockname = "new test", TestDate = DateTime.Now});
                        newTest.PropertyChanged += Test_PropertyChanged;
                        EquipTests?.Add(newTest);
                    }
                    , _ => true));
            }
        }

        /// <summary>
        /// Удалить тест
        /// </summary>
        private RelayCommand deleteTest;
        public RelayCommand DeleteTest
        {
            get 
            {
                return deleteTest ?? (deleteTest = new RelayCommand(_ => 
                {
                    SelectedTest!.PropertyChanged -= Test_PropertyChanged;
                    EquipTests?.Remove(SelectedTest!);
                }
                , _ => SelectedTest != null));
            }
        }

        /// <summary>
        /// Добавить параметр
        /// </summary>
        private RelayCommand addParameter;
        public RelayCommand AddParameter
        {
            get
            {
                return addParameter ?? (addParameter = new RelayCommand(
                    _ =>
                    {
                        var newParam = new ParameterViewModel(new Parameter() 
                        {
                            ParameterName = "new param", 
                            MeasuredValue = 0, 
                            RequiredValue = 0, 
                            TestId = SelectedTest!.Entity.TestId 
                        });
                        newParam.PropertyChanged += Parameter_PropertyChanged;
                        ParameterTests?.Add(newParam);
                    }
                    , _ => SelectedTest != null));
            }
        }
        /// <summary>
        /// Удалить параметр
        /// </summary>
        private RelayCommand deleteParameter;
        public RelayCommand DeleteParameter
        {
            get
            {
                return deleteParameter ?? (deleteParameter = new RelayCommand(_ =>
                {
                    SelectedParameter!.PropertyChanged -= Parameter_PropertyChanged;
                    ParameterTests?.Remove(SelectedParameter!);
                }
                , _ => SelectedParameter != null));
            }
        }
        #endregion

        #region .ctor
        public MainViewModel(IEquipTestDataProvider<Test> equipTestData, IEquipTestDataProvider<Parameter> paramData)
        {
            equipTestDataProvider = equipTestData ?? throw new ArgumentNullException();
            paramTestDataProvider = paramData ?? throw new ArgumentNullException();

            // При изменении выбранного теста обновляем список параметров 
            // в соответствии с выбранным тестом
            PropertyChanged += (o, e) =>
            {
                if (e.PropertyName == nameof(SelectedTest))
                {
                    RefreshParameters(SelectedTest);
                }
            };

            // Получаем список тестов
            RefreshData();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Обновить список параметров теста
        /// </summary>
        /// <param name="test">Тест</param>
        private void RefreshParameters(TestViewModel? test)
        {
            if (test != null)
            {
                ParameterTests = new ObservableCollection<ParameterViewModel>(
                    paramTestDataProvider.GetAll()
                    //TODO Не оптимально фильтровать на клиенте
                    //для фильтрации на SQL сервере надо переработать интефейс доступа к данным
                    .Where(t => t.TestId == test.Entity.TestId)
                    //Преобразуем модели к вьюмоделям
                    .Select(x =>
                    {
                        var par = new ParameterViewModel(x);
                        //Если данные в ParameterViewModel изменятся
                        par.PropertyChanged += Parameter_PropertyChanged;
                        return par;
                    }));
                //Если коллекция параметров изменится
                ParameterTests.CollectionChanged += ParameterTests_CollectionChanged;
            }
            else
                ParameterTests = [];
        }

        /// <summary>
        /// Обработка измений коллекции параметров теста
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ParameterTests_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    //Добавляем новый параметр бд
                    if (e.NewItems != null && e.NewItems.Count > 0)
                    {
                        var added = e.NewItems[0] as ParameterViewModel;
                        if (added != null)
                            paramTestDataProvider.Add(added.Entity);
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    //Удаляем параметр из бд
                    if (e.OldItems != null && e.OldItems.Count > 0)
                    {
                        var delete = e.OldItems[0] as ParameterViewModel;
                        if (delete != null)
                            paramTestDataProvider.Delete(delete.Entity);
                    }
                    break;
            }
        }

        /// <summary>
        /// Обработка изменений ParameterViewModel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Parameter_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var param = sender as ParameterViewModel;
            if (param != null)
            {
                //Обновляем данные о параметрах в бд
                paramTestDataProvider.Update(param.Entity);
            }
        }

        /// <summary>
        /// Обновляет список тестов
        /// </summary>
        private void RefreshData()
        {
            EquipTests = new ObservableCollection<TestViewModel>(
                equipTestDataProvider.GetAll().
                Select(x=> 
                {
                    var test = new TestViewModel(x); 
                    //Если днные теста изменятся
                    test.PropertyChanged += Test_PropertyChanged; 
                    return test; 
                }));
            //Если коллекция тестов изменится
            EquipTests.CollectionChanged += EquipTests_CollectionChanged;
            if (EquipTests.Count > 0)
                SelectedTest = EquipTests[0];
        }

        /// <summary>
        /// Обработка изменений TestViewModel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Test_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var test = sender as TestViewModel;
            if (test != null) 
            {
                //Обновляем данные о тесте в бд
                equipTestDataProvider.Update(test.Entity);
            }
        }

        /// <summary>
        /// Обработка изменений коллекции тестов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EquipTests_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    //Добавляем новый тест в бд
                    if (e.NewItems != null && e.NewItems.Count > 0)
                    {
                        var added = e.NewItems[0] as TestViewModel;
                        if (added != null)
                            equipTestDataProvider.Add(added.Entity);
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    //Удаляем тест из бд
                    if (e.OldItems != null && e.OldItems.Count > 0)
                    {
                        var delete = e.OldItems[0] as TestViewModel;
                        if (delete != null)
                            equipTestDataProvider.Delete(delete.Entity);
                    }
                    break;
            }
        }
        #endregion
    }
}
