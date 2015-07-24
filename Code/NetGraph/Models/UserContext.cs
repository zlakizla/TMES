///////////////////////////////////////////////////////////
//  UserContext.cs
//  Implementation of the User Context class
//  This class contains Entity Framework Code First logic. 
//  Created on:      10:37 11.04.2015
//  Developer: Dergachev Constantine
///////////////////////////////////////////////////////////

using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;

public static class AppContext
{

    private static List<CalendarGraph> _calendarGraph;

    public static List<CalendarGraph> CalendarGraph
    {
        get
        {
            if (_calendarGraph == null)
            {
                _calendarGraph = new List<CalendarGraph>();
            }
            return _calendarGraph;
        }
    }


    public static CalendarGraph FindByOrder(string Order)
    {
        var Result = CalendarGraph.FirstOrDefault(x => x.Order == Order);
        return Result;
    }

    public static List<Department> _departments;
    public static List<Department> Departments
    {
        get
        {
            if (_departments == null)
            {
                _departments = new List<Department>();
            }
            return _departments;
        }
        set
        {
            _departments = value;
        }
    }

}