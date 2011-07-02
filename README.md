A .NET client for the SlideShowPro Director API
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

- MVC 3 integration
- Caching

License
-------

Apache License 2.0