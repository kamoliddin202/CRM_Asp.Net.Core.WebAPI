

// Custom exceptions - foydalanvuchi tomnoidan yartilgan exception bo'lib u standard .Net exceptionlarga qo'shimcha qo'shish uchun ishlatiladi. 
// standard exceptionlar har doim ham yetarli emas. 
// Dasturimiz talabidan kelib chiqib BiznezLogicga mos keladigan aniq exceptionlar yaratish kerak.
// xatolarni o'zi uchun maxsus malutmot bilan to'ldirish mumkin.
// Koddi tushinish osonlashadi. Muammolarni degub qilish osonlashadi. 
// inner exception original exceptionni track qiladi. 


//throw new FileNotFoundException();


using System.Runtime.Serialization;

throw new MyCustomException();



public class MyCustomException : Exception
{
    public MyCustomException() 
        : base() 
    {}
    public MyCustomException(string  message) 
        : base(message)
    {}

    public MyCustomException(string message, Exception innerException)
        :base(message, innerException) 
    {}

    public MyCustomException(SerializationInfo serializationEntries, StreamingContext context) 
        :base(serializationEntries, context) 
    {}  



}