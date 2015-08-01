using AECSCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Utils;

namespace NetGraph.ViewModels
{
    public class ExploderViewModel
    {
        public CalendarGraph CalendarGraph { get; set; }

        private ICollection<Element> _navigationMenu;
        /// <summary>
        /// List of elements at the navigation menu
        /// </summary>
        public ICollection<Element> NavigationMenu 
        { 
            get
            {
                if(_navigationMenu == null)
                {
                    _navigationMenu = new List<Element>();
                }
                return _navigationMenu;
            }
            set
            {
                _navigationMenu = value;
            }
        }

        public Element SelectedElement
        {
            get;
            set;
        }

        public ExploderViewModel(CalendarGraph CalendarGraph)
        {
            if(CalendarGraph == null)
            {
                return;
            }
            this.CalendarGraph = CalendarGraph;
            var Root = Element.Root();
            foreach(var Position in CalendarGraph.Order.Content)
            {
                Root.Content.Add(Position);
            }
            NavigationMenu.Add(Root);
           
            SelectedElement = Root;  
        }
    }
}