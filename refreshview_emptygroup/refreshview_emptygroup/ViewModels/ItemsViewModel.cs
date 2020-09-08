using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using refreshview_emptygroup.Models;
using refreshview_emptygroup.Views;
using System.Collections.Generic;
using System.Linq;

namespace refreshview_emptygroup.ViewModels
{
    public class ContentGroupHolder<TCollectionItem>
        : ObservableCollection<TCollectionItem>
    {

        public string GroupContent { get; private set; }


        public ContentGroupHolder(string content, IList<TCollectionItem> items)
        {
            items = items ?? new TCollectionItem[0];

            foreach (var item in items)
            {
                this.Add(item);
            }

            GroupContent = content;
        }
    }


    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<ContentGroupHolder<Item>> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<ContentGroupHolder<Item>>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();

                var temp = new List<ContentGroupHolder<Item>>();

                foreach (var i in Enumerable.Range(0, 2))
                {
                    var items = (await DataStore.GetItemsAsync(true)).ToArray();
                    temp.Add(new ContentGroupHolder<Item>($"group-{i}", items));
                }

                foreach (var item in temp)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}