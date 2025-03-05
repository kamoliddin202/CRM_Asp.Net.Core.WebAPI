

// Custom exceptions - foydalanvuchi tomnoidan yartilgan exception bo'lib u standard .Net exceptionlarga qo'shimcha qo'shish uchun ishlatiladi. 
// standard exceptionlar har doim ham yetarli emas. 
// Dasturimiz talabidan kelib chiqib BiznezLogicga mos keladigan aniq exceptionlar yaratish kerak.
// xatolarni o'zi uchun maxsus malutmot bilan to'ldirish mumkin.
// Koddi tushinish osonlashadi. Muammolarni degub qilish osonlashadi. 
// inner exception original exceptionni track qiladi. 


//throw new FileNotFoundException();


//using System.Runtime.Serialization;

//throw new MyCustomException();



//public class MyCustomException : Exception
//{
//    public MyCustomException() 
//        : base() 
//    {}
//    public MyCustomException(string  message) 
//        : base(message)
//    {}

//    public MyCustomException(string message, Exception innerException)
//        :base(message, innerException) 
//    {}

//    public MyCustomException(SerializationInfo serializationEntries, StreamingContext context) 
//        :base(serializationEntries, context) 
//    {}  



//}


using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;

bool VeryfyPassword(string hashedPassword, string providedPasswor)
{
    var passwordHasher = new PasswordHasher<object>();
    var result = passwordHasher.VerifyHashedPassword(null, hashedPassword, providedPasswor);

    return result == PasswordVerificationResult.Success; 
}


Console.WriteLine(VeryfyPassword("AQAAAAIAAYagAAAAENdiFvwcbENF5E5Q8q5LsnRGF5e2+hyrsg9XHq4PHdC9OI72iGvUWZLI6McNIAd0rw==", "Admin.123$"));

