if exist packages-temp rmdir /S /Q packages-temp

mkdir packages-temp
mkdir packages-temp\director
mkdir packages-temp\director\lib
mkdir packages-temp\director\lib\net4
mkdir packages-temp\director\lib\net4-client

copy source\SlideShowPro.Director\bin\Release\SlideShowPro.Director.dll packages-temp\director\lib\net4
copy source\SlideShowPro.Director\bin\Release\SlideShowPro.Director.dll packages-temp\director\lib\net4-client

tools\NuGet.exe pack slideshowpro.director.nuspec -BasePath packages-temp\director -OutputDirectory packages-temp