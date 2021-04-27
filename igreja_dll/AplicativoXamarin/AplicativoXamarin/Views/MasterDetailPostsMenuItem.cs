using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AplicativoXamarin.Views
{

    public class MasterDetailPostsMenuItem
    {
        public MasterDetailPostsMenuItem()
        {
            TargetType = typeof(MasterDetailPostsDetail);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }

        public ContentView content { get; set; }
    }
}