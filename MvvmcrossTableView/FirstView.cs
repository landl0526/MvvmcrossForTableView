using System;
using System.Drawing;

using CoreFoundation;
using UIKit;
using Foundation;
using MvvmCross.Platforms.Ios.Views;
using MvvmCross.Binding.BindingContext;
using CoreGraphics;
using MvvmCross.Platforms.Ios.Binding.Views;
using System.Collections.Generic;
using MvvmCross.Binding.Extensions;
using System.Linq;

namespace MvvmcrossTableView
{
    [Register("FirstView")]
    public class FirstView : MvxViewController
    {

        UITableView TableView = new UITableView();

        public FirstView()
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            View.BackgroundColor = UIColor.White;
            // Perform any additional setup after loading the view

            View.AddSubview(TableView);
            TableView.Frame = View.Bounds;
            var source = new TableSource(TableView);

            TableView.Source = source;
            TableView.RowHeight = 120f;
            TableView.ReloadData();

            var set = this.CreateBindingSet<FirstView, FirstViewModel>();

            set.Bind(source).For(s => s.ItemsSource).To(vm => vm.ItemsDic);

            set.Apply();
        }
    }

    public class TableSource : MvxTableViewSource
    {
        private static readonly NSString CellIdentifier = new NSString("MyTableViewCell");

        private Dictionary<string, List<Item>> savedItemList;

        public TableSource(UITableView tableView)
                : base(tableView)
        {
            tableView.SeparatorStyle = UITableViewCellSeparatorStyle.None;
            tableView.RegisterNibForCellReuse(UINib.FromName("MyTableViewCell", NSBundle.MainBundle),
                                              CellIdentifier);
        }


        protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
        {
            return TableView.DequeueReusableCell(CellIdentifier, indexPath);
        }


        protected override object GetItemAt(NSIndexPath indexPath)
        {
            return savedItemList.Values.ToList()[indexPath.Section][indexPath.Row];
        }

        public override nint NumberOfSections(UITableView tableView)
        {
            if (ItemsSource != null)
            {
                savedItemList = (Dictionary<string, List<Item>>)ItemsSource;
                return savedItemList.Count();
            }           
            return 0;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            if (ItemsSource != null)
            {
                savedItemList = (Dictionary<string, List<Item>>)ItemsSource;
                return savedItemList.Values.ToList()[(int)section].Count;
            }
            return 0;
        }

        public override string TitleForHeader(UITableView tableView, nint section)
        {
            return string.Format($"Header for section");
        }
    }
}