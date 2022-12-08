using EntryPoint.Characters.Warriors;
/*
Warrior GoodGuy = new Warrior();
GoodGuy.Height = 160;
GoodGuy.Weight = 64;
GoodGuy.Name = "Pavan";
*/

/*Warrior BadGuy = new Warrior();
BadGuy.Height = 145;
BadGuy.Weight = 72;
BadGuy.Name = "Bad Guy";
*/

Warrior GoodGuy = new Warrior(160, 64, "Pavan");
Warrior BadGuy = new Warrior(145, 72, "Bad Guy");

Console.WriteLine(GoodGuy.Height);
Console.WriteLine(BadGuy.Height);

//GoodGuy and BadGuy Greeting eachother
GoodGuy.Greetings(BadGuy);
GoodGuy.Greetings(GoodGuy);


Console.ReadLine();


