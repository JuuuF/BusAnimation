using Mapsui;
using Mapsui.Projections;
using Mapsui.Tiling;

namespace BusAnimation.Image;

public class MapCreation(double lat = 54.43233, double lon = 10.1394)
{
    private double lat { get; set; } = lat;
    private double lon { get; set; } = lon;

    public async Task<Map> GetMapAsync()
    {
        // Create base map
        var map = new Map();

        // Add OSM tile
        map.Layers.Add(OpenStreetMap.CreateTileLayer());

        // Set size and zoom
        var (centerX, centerY) = SphericalMercator.FromLonLat(lon: lon, lat: lat);
        map.Navigator.SetSize(800, 600);
        map.Navigator.ZoomToBox(map.Extent);
        map.Navigator.CenterOnAndZoomTo(new Mapsui.MPoint(centerX, centerY), resolution: 25);

        // Load map data
        await map.RefreshDataAsync();

        return map;
    }
}
