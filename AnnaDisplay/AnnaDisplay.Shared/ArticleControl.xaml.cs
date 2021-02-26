using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace AnnaDisplay.Shared
{
    public sealed partial class ArticleControl : UserControl
    {
        public ArticleControl()
        {
            this.InitializeComponent();
        }

        [Description("The Title of the Article"), Category("Data")]
        public string Title
        {
            get => ArticleTitle.Text;
            set => ArticleTitle.Text = value;
        }

        [Description("The Topic of the Article"), Category("Data")]
        public string Topic
        {
            get => ArticleTopic.Text;
            set => ArticleTopic.Text = value;
        }

        /*[Description("The Link to the Article"), Category("Data")]
        public Uri Link
        {
            get => ArticleLink.NavigateUri;
            set => ArticleLink.NavigateUri = value;
        }*/

        [Description("The Link to the Article for the Text"), Category("Data")]
        public string LinkText
        {
            get => ArticleLinkText.Text;
            set => ArticleLinkText.Text = value;
        }
    }
}
