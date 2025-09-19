<div dir="rtl">

# پروژه FanapShop

## توضیح پروژه
FanapShop یک پروژه نمونه با معماری **Clean Architecture** است که هدف آن جداسازی لایه‌ها، نگهداری منطق بیزینسی در **دامین** و سهولت در تست و توسعه تغییرات بیزینسی می‌باشد.

## معماری
- **Clean Architecture**:  
  لایه‌ها جدا شده‌اند (Domain, Application, Infrastructure, API) تا **dependency rule** رعایت شود و تغییرات هر لایه محدود به همان لایه باشد.
- **Rich Domain Model**:  
  منطق بیزینسی در کلاس‌های دامنه قرار دارد، باعث می‌شود تست و نگهداری آسان شود.

## دامین
- **User Base Class**: یک کلاس پایه با فیلدهای مشترک مثل `FirstName`, `LastName`, `Email`, `PasswordHash`.  
- **Admin و Customer**: کلاس‌های Concreate که از User ارث می‌برند.  
- **TPH (Table Per Hierarchy)**: برای نگهداری Userها با یک ستون `Role` در دیتابیس.  
- **Value Object برای تراکنش‌ها**:  
  لیست تراکنش‌های مشتری در **Customer** به عنوان Value Object تعریف شده و در یک ستون JSON ذخیره می‌شود.

## Authentication
- استفاده از **JWT** برای لاگین ساده و امن.  
- هندل کردن **چند نوع کاربر** (Admin و Customer).  

## ابزارها و تکنولوژی‌ها
- **MediatR**: برای مدیریت Command و Queryها و جداسازی لایه Application.  
- **Entity Framework Core**: برای دسترسی به دیتابیس و پیاده‌سازی TPH و JSON Value Object.  
- **.NET 9**: فریم‌ورک اصلی پروژه.
- **XUnit**: فریم‌ورک تست.

## مزایای پروژه
- منطق بیزینسی کاملاً در دامنه متمرکز است.  
- تست‌پذیری بالا به دلیل استفاده از Rich Domain Model.  
- تغییرات بیزینسی راحت و ایمن.  
- مدیریت کاربران مختلف با Roleهای متفاوت.  
- ذخیره تراکنش‌ها به صورت JSON داخل دامنه مشتری برای دسترسی سریع و بدون نیاز به جدول جداگانه.

</div>
