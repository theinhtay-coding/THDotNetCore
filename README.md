### AdoDotNetCRUDExample	=> done

### DapperCRUDExample		=> done

### EFCoreCRUDExample		=> done

### RestApi CRUD Project	=> done
##### DapperController(Entity Framework)
##### BlogDapperController

### AdoDotNetService		=> done
### DapperService			=> done

### RestApiWithNLayer		=> done
### Burmese Project Idea	=> Inprogress

### ConsoleAppHttpClientExamples	=> done
### ConsoleAppRestClientExamples	=> done

Git commit format => <type>[scope]: <subject>
example: docs: update README to add developer tips

Type =>

feat: A new feature or enhancement added to the codebase.

fix: A bug fix or correction to resolve an issue.

docs: Documentation changes or updates.

style: Changes related to code formatting, indentation, or whitespace.

refactor: Code refactoring without adding new features or fixing bugs.

test: Addition or modification of test cases.

chore: Other changes not directly affecting the code (e.g., build scripts, dependencies).

perf: A code changes that improve performance

ci: change your CI integration file and scripts.

build: Changes that effect the build system or external dependencies (example scopes: gulp, broccoli, npm)

temp: Tempory commit that won't be include in your CHANGELOG


Scope =>
Optional, can be anything specifying the scope of the commit change.

For example $location, $browser, $ngClick, etc

In app development, scope can be a page, a module, or component.


Subject => 

Berif summary of the change in present tense. Not capitalized. No period at the end.


ApexChart
https://apexcharts.com/


ChartJS
https://www.chartjs.org/docs/latest/
https://github.com/chartjs/Chart.js/blob/master/docs/scripts/utils.js

HighChart
https://www.highcharts.com/demo


SignalR
https://learn.microsoft.com/en-us/aspnet/core/tutorials/signalr?view=aspnetcore-8.0&tabs=visual-studio

Database First in PackageManager Console
Scaffold-DbContext "Server=.;Database=THDotNetCore;User ID=sa;Password=r00tp@ss;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Context AppDbContext


Database First in Terminal
dotnet ef dbcontext scaffold "Server=.;Database=DbName;User Id=userId;Password=password;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models -c AppDbContext -t Tbl_Name -f

dotnet ef dbcontext scaffold "Server=.;Database=THDotNetCore;User Id=sa;Password=r00tp@ss;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models -c AppDbContext -f
dotnet tool install --global dotnet-ef --version 8
Notes => Need to remove OnConfiguration function in AppDbContext
We shoud separate class file for database first.

