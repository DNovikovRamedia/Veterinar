rd /s /q C:\Staging\Veterinar\
%windir%\Microsoft.NET\Framework\v2.0.50727\aspnet_compiler -p "C:\dev\Veterinar\Web" -v / C:\Staging\Veterinar -u -fixednames
erase C:\Staging\Veterinar\*.bat
erase C:\Staging\Veterinar\bin\*.pdb
"%ProgramFiles%\MSBuild\Microsoft\WebDeployment\v8.0\aspnet_merge.exe" C:\Staging\Veterinar -a -w VeterinarWeb.dll
erase C:\Staging\Veterinar\web.config
erase C:\Staging\Veterinar\errors.html
rd /s /q C:\Staging\Veterinar\i\
rd /s /q C:\Staging\Veterinar\fckeditor\
fixenc C:\dev\Veterinar\Web\ C:\Staging\Veterinar\
