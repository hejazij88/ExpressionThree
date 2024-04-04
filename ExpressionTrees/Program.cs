// See https://aka.ms/new-console-template for more information


using System.Linq.Expressions;

var isValid = bool (Person p) => p.Id < 5000;

Console.WriteLine(isValid(new Person{Id = 5001}));

ParameterExpression p= Expression.Parameter (typeof(Person), "p");
MemberExpression id= Expression.Property(p, "id");
ConstantExpression number = Expression.Constant(5000, typeof(int));
BinaryExpression body= Expression.GreaterThan(id, number);
var isVadlidExpression= Expression.Lambda<Func<Person,bool>>(body,p);

var method=isVadlidExpression.Compile();
Console.WriteLine(method(new Person{Id = 5001}));

public class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
}

