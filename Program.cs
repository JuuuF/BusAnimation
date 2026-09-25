using Mapsui;
using Mapsui.UI;
using Mapsui.Tiling;
using Mapsui.Extensions;
using Mapsui.Projections;
using Mapsui.Rendering.Skia;

// 1. Create Map
var map = new Map();
// {
//     BackColor = Mapsui.Styles.Color.DarkGray
// };

// 2. Add OSM tile layer
map.Layers.Add(OpenStreetMap.CreateTileLayer());

map.Navigator.SetSize(800, 600);
map.Navigator.ZoomToBox(map.Extent);

// 3. Define map center
var (centerX, centerY) = SphericalMercator.FromLonLat(lon: 10.1394, lat: 54.3233);
map.Navigator.CenterOnAndZoomTo(new Mapsui.MPoint(centerX, centerY), resolution: 25);

// 5. Fetch viewport data
Console.WriteLine("Fetching viewport data...");
await map.RefreshDataAsync();

// 6. Instanciate Skia renderer
Console.WriteLine("Rendering map to stream...");

var renderer = new MapRenderer();
using var stream = renderer.RenderToBitmapStream(map);
await File.WriteAllBytesAsync("data/map.png", stream.ToArray());
