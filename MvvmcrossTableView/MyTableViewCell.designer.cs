// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace MvvmcrossTableView
{
    [Register ("MyTableViewCell")]
    partial class MyTableViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel LBL_NAME { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (LBL_NAME != null) {
                LBL_NAME.Dispose ();
                LBL_NAME = null;
            }
        }
    }
}