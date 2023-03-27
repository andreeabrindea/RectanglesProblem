# Rectangles Problem

### Description:
#### Given some points in cartesian coordinate, (x, y) find the number of rectangles that can be created by those points. Consider only the rectangles that are parallel with the X, Y axes.

### State the solution:
#### The solution is implemented in C# and the points are taken from an input.txt file. 
#### To make sure that the points are entered corectly, I created a regular expression of the form, (@"\(\s*(\d+)\s*,\s*(\d+)\s*\)"), which means that (x, y) should be integers separatd by a comma and bewteen round brackets.
#### The points are stored in a list of the form <int, int> and then rearranged in a dictionary. I grouped the points by their x coordinates, where x is the key and the y coordinates contained in a point with a x coordinate as values. As an example, consider the points (1,1), (1,3), (2,1), (3,1), (3,3), the dictionary will look as follows: 
#### 1: 1, 3
#### 2: 1, 3
#### 3: 1, 3
#### I created this dictonary to find the intersections of the y coordinates for each pair of xcoordinates. I will compare the values from the key = 1 with the values from the key = 2, the values from the key = 1 with the values from the key = 3 and, lastly, the values from key = 2 with the values from key = 3 and take the number of common values for each case.
#### Moving on, if the number of common values is an even number, the number of rectangles are computed as follows, because two pairs of points are needed to construct a rectangle:
```ruby
noRectangles = noRectangles + valuesContained.Count() / 2; 
```
#### On the other hand, if the number of common values is an odd number bigger than 1, the number of rectangles are computed as follows, because already having 2 pairs of points, if you add one more pair, you will have 3 rectangles:
```ruby
noRectangles = noRectangles + valuesContained.Count(); 
```
### Important aspect:
![image](https://user-images.githubusercontent.com/79668619/228051418-1c3bfa35-86d2-4088-b341-92a1ba84563f.png)
#### Given the points: (1,1), (1,2), (1,3), (2,1), (2,2), (2,3), (3,1), (3,2), (3,3) my solution will find 9 rectangles. Squares are considered rectangles, 
### User guide:
#### When running the app, the path from the file should be changed, as C# has such a not nice way to handle files :D

