using System.Text.RegularExpressions;

// reading the input data
string input = File.ReadAllText("C:\\Users\\andre\\source\\repos\\CartesianCoordinates\\CartesianCoordinates\\input.txt");

// use a regular expression to store the points 
// the points will be added as (p1, p2), (p3, p4) where p1, p2, p3 and p4 are all integers.
var regex = new Regex(@"\(\s*(\d+)\s*,\s*(\d+)\s*\)");

var coordinates = regex.Matches(input)
    .Cast<Match>()
    .Select(m => Tuple.Create(int.Parse(m.Groups[1].Value), int.Parse(m.Groups[2].Value)))
    .ToList(); 

// creates a dictionary to store the values as follows:
//          x1: y1, y2, y3
//          x2: y1, y2, y4
//          x3: y1, y2, y5
// So, it groups the x coordinate with all the y coordinate that are present alongside x in a point 

var valuesWithX = new Dictionary<int, List<int>>();

// loop throgh all the points
foreach (var coord in coordinates)

{   //store the x and y coordinates of each point separately
    int x = coord.Item1;
    int y = coord.Item2;

    // if x does not exist in the dictionary, it needs to be added
    if (!valuesWithX.ContainsKey(x))
    {
        valuesWithX[x] = new List<int>();
    }
    // if x exist, we have only to add y
    valuesWithX[x].Add(y);

}
// create a variable to keep track of the number of rectangles
var noRectangles = 0;

// the rest of the code suppose to make the intersections between the values (y coordinates) of each key (x coordinate) from the dictionary 
// if there are more than 2 common elements => +1 rectangle


// loop through the dictionary, excluding the last element
for (int i = 0; i < valuesWithX.Count; i++)
{   
    // j will be the next element after the element at the index i, so we can compare all of them  
    for (int j = i + 1; j < valuesWithX.Count; j++)
    {
        // verify if the element at index j contains the values from the element at the index i 
        var valuesContained = valuesWithX.ElementAt(i).Value.Where(x => valuesWithX.ElementAt(j).Value.Contains(x));
        // if there are more than 2 common values => +1 rectangle
        // if there are 4 common values => +2 rectagles
        // and same idea if there are 6 common values => +3 rectangles
        if (valuesContained.Count() % 2 == 0)
        {
            noRectangles = noRectangles + valuesContained.Count() / 2;
        }
        else
           // if there are 3 common values => +1 rectangle 
        {   // if there are 5 common values => +2 rectangles 
            if (valuesContained.Count() > 1)
            {
                noRectangles = noRectangles + valuesContained.Count();
            }
        }

    }
}

Console.WriteLine(noRectangles);
