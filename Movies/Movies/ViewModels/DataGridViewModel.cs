using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

using Movies.Core.Models;
using Movies.Core.Services;
using Movies.Helpers;

namespace Movies.ViewModels
{
    public class DataGridViewModel : Observable
    {
        public ObservableCollection<SampleOrder> Source { get; } = new ObservableCollection<SampleOrder>();

        public DataGridViewModel()
        {
        }

        public async Task LoadDataAsync()
        {
            Source.Clear();

            // TODO WTS: Replace this with your actual data
            var data = await SampleDataService.GetGridDataAsync();

            foreach (var item in data)
            {
                Source.Add(item);
            }
        }
    }
}
