using Rock_Paper_Scissors_CSharp.lib;

namespace Rock_Paper_Scissors_CSharp.utils;

/// <summary>
/// The middleware between render and text file with the layouts to render the
/// game field  
/// </summary>
public static class FileNode
{
    /// <summary>
    /// Contains the directory path to the file where the program
    /// can get the layouts 
    /// </summary>
    /// <returns>Path string</returns>
    private static string Path()
    {
        return "./lib/SymbolLayouts.txt";
    }

    /// <summary>
    /// Simple loads the content of a text file for example
    /// - Can set the default layout of it, when needed
    /// </summary>
    /// <returns>List of all lines in a file</returns>
    private static List<string> LoadContent()
    {
        if (!File.Exists(Path()))
        {
            File.Create(Path());
        }
        
        //counter of how many attemps the program can make to read from the textfile
        int tries = 3;

        for (int i = 0; i < tries; i++)
        {
            try
            {
                return File.ReadAllLines(Path()).ToList();
            }
            catch(IOException e)
            {
                Thread.Sleep(500);                
            }
        }

        return new List<string>();
    }

    /// <summary>
    /// Loads all lines in the from the text file
    /// Loops over them and convert all layout coordinates to a full layout model
    /// Adds all created models to a list
    /// </summary>
    /// <returns>List of all needed layouts to play a game</returns>
    public static List<LayoutModel> ConvertLayouts()
    {
        //text file lines
        List<string> lines = LoadContent();

        //layout list to return
        List<LayoutModel> layouts = new List<LayoutModel>();

        //loop over file lines
        foreach (var line in lines)
        {
            //current layout model instance to add to the list
            LayoutModel layout = new LayoutModel();

            //a line splitted up into all coordinates 
            string[] columns = line.Split('|');

            //loop over all coordinates
            foreach (var column in columns)
            {
                //get x and y coordinate
                string[] coordinates = column.Split(',');

                //x value
                int x = Convert.ToInt16(coordinates[0]);

                //y value
                int y = Convert.ToUInt16(coordinates[1]);

                //local instance off a coordinate package to add to the local layout instance
                int[] package = new int[]{};

                //add coordinates to package
                package.Append(x);
                package.Append(y);
                
                //add packages to layout model
                layout.Layout.Add(package);
            }

            //return layouts
            layouts.Add(layout);
        }

        return layouts;
    }
}