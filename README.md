.NET client for the SlideShowPro Director API
=============================================

Easily fetch content from the SlideShowPro Director publishing platform.

Usage
-----

		var director = new Director("yourslideshowhost.com");
		var galleries = director.GetGalleries();
		var albums = director.GetAlbums();
		var contents = director.GetContents();
		
Yet to implement
----------------

1. NuGet package
2. MVC 3 integration
3. Caching

License
-------

Apache License 2.0