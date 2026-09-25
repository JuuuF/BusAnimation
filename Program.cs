using BusAnimation.Image;
using Mapsui.Rendering.Skia;

// 1. Create Map
var mapCreator = new MapCreation();
var map = await mapCreator.GetMapAsync();

// 2. Create Renderer
var renderer = new MapRenderer();
using var stream = renderer.RenderToBitmapStream(map);
await File.WriteAllBytesAsync("data/map.png", stream.ToArray());
