# ReCapProject
ReCapProject, SOLID prensiplerine bağlı kalınarak ve N-Katmalı mimari yapısıyla geliştirilen bir Araç Kiralama sistemi projesidir. Projenin frontend kısmı Angular, backend kısmı ise Asp.net ile kodlanmıştır ve aralarındaki iletişim sağlanabilmesi için Web API kullanılmıştır. Veritabanı için MSSQL kullanılmıştır.

<td>&#128206;<ins><b>Projenin frontend kısmına <a href="https://github.com/ismetsandikci/ReCapProject-Frontend">buradan</a> ulaşabilirsiniz.</ins>

## Kullanılan Teknolojiler ve Sürümleri
[![C-Sharp](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![Asp-net-web-api](https://img.shields.io/badge/ASP.NET%20Web%20API-5C2D91?style=for-the-badge&logo=.net&logoColor=white)](https://dotnet.microsoft.com/apps/aspnet)
[![MSSQL](https://img.shields.io/badge/MSSQL-004880?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)](https://www.microsoft.com/en-us/sql-server/sql-server-2019?rtc=2)
[![Entity-Framework-Core](https://img.shields.io/badge/EntityFramework%20Core-v3.1.1-informational?style=for-the-badge&logo=nuget)](https://docs.microsoft.com/en-us/ef/)
[![Autofac](https://img.shields.io/badge/Autofac-v7.1-informational?style=for-the-badge&logo=nuget)](https://autofac.org/)
[![Fluent-Validation](https://img.shields.io/badge/FluentValidation-v9.5.1-informational?style=for-the-badge&logo=nuget&labelColor=orange)](https://fluentvalidation.net/)

- .Net Core 3.1
- Restful API
- Result Türleri
- Interceptor
- Autofac
    - IoC Containers
    - AOP, Aspect Oriented Programming
        - Caching
        - Performance
        - Transaction
        - Validation
- Fluent Validation
- Cache yönetimi
- JWT Authentication
- Repository Design Pattern
- Cross Cutting Concerns
    - Caching
    - Logging
    - Validation
- Extensions
    - Claim
        - Claim Principal
    - Exception Middleware
    - Service Collection
    - Error Handling
        - Error Details
        - Validation Error Details
        
## Katmanlar
- **Business Katmanı**: İş kurallarının tanımlandığı ve kontrol edildiği katmandır. Data Access katmanına uygulamamızda Business katmanı aracılığıyla iletişim sağlanıp Data Access katmanı tarafından projeye çekilen veriler Business katmanında işlenmektedir
- **ConsoleUI**: Yazılan operasyonların kontrolü için kullanılan katmandır.
- **Core Katmanı**: Core katmanı operasyonların generic yapılarla genelleştirildiği, her proje için kullanılabilecek potansiyele sahip bir katmandır.
- **Data Access Katmanı**: Veritabanı bağlantılarının ve işlemlerinin yapıldığı katmandır. Veritabanı bağlantısı için gerekli konfigürasyon burada yapılır. CRUD işlemleri bu katmanda kodlanmıştır.
- **Entities Katmanı**: Program genelinde kullanılacak nesne sınıflarının tanımlandığı yerdir. Bu katmandaki sınıfların her biri, veritabanındaki bir tabloya karşılık gelir, bunlara ek olarak, farklı tablolardan verilerin birleştirildiği DTO (Veri Aktarım Nesnesi) sınıflarını da içerir.
- **Web API**: Frontend kısmının ve diğer platformların program ile haberleşmesini ve işlem yapmasını sağlayan servislerin yazıldığı kısımdır.

## Veritabanı ve Tablolar
<td>&#128206;<ins><b>Veritabanı dosyalarına <a href="https://github.com/ismetsandikci/ReCapProject/tree/master/_databaseBackup">buradan</a> ulaşabilirsiniz.</ins>
<br>
    
![alt text](https://github.com/ismetsandikci/ReCapProject/blob/master/_databaseBackup/Database%20Diagram.jpg)

<br>

## İletişim
Aşağıdaki hesaplarımdan benimle iletişime geçebilirsiniz. 
<br>

<a href="https://github.com/ismetsandikci" target="_blank">

![alt text](https://img.shields.io/badge/GitHub-100000?style=for-the-badge&logo=github&logoColor=white)
</a>

<a href="https://www.linkedin.com/in/ismetsandikci" target="_blank">

![alt text](https://img.shields.io/badge/LinkedIn-0077B5?style=for-the-badge&logo=linkedin&logoColor=white)

</a>
