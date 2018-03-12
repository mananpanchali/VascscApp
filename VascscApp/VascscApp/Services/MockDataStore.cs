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
                new Item { Id = Guid.NewGuid().ToString(), Image="scienceforum.jpg", Text = "School Science Forum", Description="The VASCSC School Science Forum (SSF) programme successfully entered into its second year; it is now extended up to Std. IX. This syllabus oriented, year-long programme has received overwhelming response from 435 participants, as well as parents. It has become one of the most sought after programmes of VASCSC. The objective of this programme was to facilitate practical learning of science and mathematics by providing the students, an opportunity to strengthen the basic concepts of these subjects through experiments and activities, conducted in the Centre's well-equipped labs. The programme started on 15 July 2012. 30 sessions were conducted for each standard covering topics that required practical input as well as educational visits." },
                new Item { Id = Guid.NewGuid().ToString(), Image="summer.jpg", Text = "Summer Programmes", Description="These programmes are conducted during the school summer breaks from April to June every year. Interesting and hands-on activities in fields like computers, physics, chemistry, applied mathematics, astronomy and biology make these programmes highly sought-after.Summer programmes are announced during the month of April. The details are then available on the Centre's notice board as well as on the website." },
                new Item { Id = Guid.NewGuid().ToString(), Image="Logo.png", Text = "Teacher Training Programmes", Description="Computer The Education Department, Government of Gujarat has designated VASCSC as one of the recognized training Centres for computer training. Training programmes for secondary and higher secondary computer teachers are conducted through pre - announced batches.Further information can be availed from the Computer department or mail us at info@vascsc.org." },
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