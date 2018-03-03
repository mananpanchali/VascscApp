using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using VascscApp.Models;

[assembly: Xamarin.Forms.Dependency(typeof(VascscApp.Services.MockDataStore))]
namespace VascscApp.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>();
            var mockItems = new List<Item>
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "6-7 Apr 2017", Description="Hands-on approaches in Science and Mathematics Education." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "17-19 May 2017", Description="Hands-on approaches in Science Education." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "4-8 July 2017", Description="Computer Teachers Training." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "4-5 July 2017", Description="Model Rocketry Workshop." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "7-8 July 2017", Description="Model Rocketry Workshop." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "11-15 July 2017", Description="Computer Teachers Training." },
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var _item = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(Item item)
        {
            var _item = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}