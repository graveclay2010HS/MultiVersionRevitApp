#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Diagnostics;

#endregion

namespace MuliVersionRevitApp
{
    [Transaction(TransactionMode.Manual)]
    public class TestAPI : IExternalCommand
    {

        private string getVersion ()
        {
#if REVIT2019
            return "Revit 2019";
#elif REVIT2020
            return "Revit 2020";
#elif REVIT2021
            return "Revit 2021";
#elif REVIT2022
            return "Revit 2022";
#else
            return "Revit 2023";
#endif
        }

        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            //Which Version is this
            TaskDialog scMessage = new TaskDialog("Revit Version");
            scMessage.MainContent = "You are working with " + getVersion() + "!";
            scMessage.Show();
            return Result.Succeeded;
        }
    }
}
