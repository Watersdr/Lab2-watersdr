using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    public class Presenter
    {
        private IView view;
        //private IWebService service;

        public Presenter(IView view)
        {
            this.view = view;
            this.view.Load+=new EventHandler(view_Load);
            //view.Load += view_Load;
        }

       /*
        public Presenter(IView view, IWebService ws)
        {
            this.view = view;
            this.service = ws;
            view.Load += view_Load;
        }
        */

        void view_Load(object sender, EventArgs e)
        {
            throw new Exception("Not Implemented");
        }
    }


}
