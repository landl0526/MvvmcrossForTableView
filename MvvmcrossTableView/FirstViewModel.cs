using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using MvvmCross.ViewModels;
using UIKit;

namespace MvvmcrossTableView
{
    public class FirstViewModel : MvxViewModel
    {

        public FirstViewModel()
        {

            ItemsGroup = new List<SessionGroup>();
            for (int i=0; i<3; i++)
            {
                var list = new List<Item>();
                for (int j=0; j<10; j++)
                {
                    list.Add(new Item { Name = "Section:" + i + "Item" + j });
                }
                ItemsGroup.Add(new SessionGroup("section" + i, list));
            }
        }


        private List<SessionGroup> _ItemsGroup;
        public List<SessionGroup> ItemsGroup
        {
            get
            {
                return _ItemsGroup;
            }
            set
            {
                _ItemsGroup = value;
                RaisePropertyChanged(() => ItemsGroup);
            }
        }
    }

    public class Item
    {
        public string Name { set; get; }
    }

    public class SessionGroup : List<Item>
    {
        public string Key { get; set; }

        public SessionGroup(string key, List<Item> items) : base(items)
        {
            Key = key;
        }
    }
}