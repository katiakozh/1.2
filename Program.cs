ILongLong a = new LongLong(1234373735672, 1257572572457);
LongLong b = new LongLong(1234373735672, 1257572572457);
LongLong c = new LongLong(123456789024253, 132465467577686899);
bool exit = false;
while (!exit)
{
    Console.WriteLine("Выберите операцию:");
    Console.WriteLine("1. Сложение");
    Console.WriteLine("2. Вычитание");
    Console.WriteLine("3. Умножение");
    Console.WriteLine("4. Деление");
    Console.WriteLine("5. Сравнение чисел");
    Console.WriteLine("6. Вывод чисел");
    Console.WriteLine("7. Выход");

    int choice = int.Parse(Console.ReadLine());

    switch (choice)
    {
        case 1:
            LongLong z = c + b;
            z.ToString();
            break;
        case 2:
            LongLong q = c - b;
            q.ToString();
            break;
        case 3:
            LongLong w = c * b;
            w.ToString();
            break;
        case 4:
            LongLong e = c / b;
            e.ToString();
            break;
        case 5:
            int x = b.Compare(c, b);
            if (x == 0)
            {
                Console.WriteLine("Числа равны");
            }
            else if (x == 1)
            {
                Console.WriteLine("Число 1 больше числа 2");
            }
            else
            {
                Console.WriteLine("Число 1 меньше числа 2");
            }
            break;
        case 6:
            Console.WriteLine("Число a:");
            a.ToString();
            Console.WriteLine("Число b:");
            b.ToString();
            Console.WriteLine("Число c:");
            c.ToString();
            break;
        case 7:
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Неверный выбор. Пожалуйста, выберите снова.");
            break;
    }
}
interface ILongLong
{
    public int Compare(LongLong a, LongLong b);
    public void ToString();
}
abstract class AbsLongLong : ILongLong
{
    public long _high;
    public long _low;
    public abstract int Compare(LongLong a, LongLong b);
    public abstract void ToString();
}
class LongLong : AbsLongLong
{
    public LongLong(long high, long low)
    {
        _high = high;
        _low = low;
    }
    public static LongLong operator +(LongLong a, LongLong b)
    {
        long high = a._high + b._high;
        long low = a._low + b._low;

        return new LongLong(high, low);
    }
    public static LongLong operator -(LongLong a, LongLong b)
    {
        long high = a._high - b._high;
        long low = a._low - b._low;

        if (low < 0)
        {
            low += (1L << 64);
            high--;
        }

        return new LongLong(high, low);
    }
    public static LongLong operator *(LongLong a, LongLong b)
    {
        long low1 = a._low;
        long high1 = a._high;
        long low2 = b._low;
        long high2 = b._high;

        long r0 = long.MaxValue;


        long high = high1 * high2;
        long low = low1 * low2;
        if (low >= r0)
        {
            high += 1;
            low = low % r0;
        }

        return new LongLong(high, low);
    }
    public static LongLong operator /(LongLong a, LongLong b)
    {
        if (b._high == 0 && b._low == 0)
        {
            throw new DivideByZeroException();
        }
        long qhigh = 0;
        long qlow = 0;
        while (a.Compare(a, b) >= 0)
        {
            a -= b;
            qhigh++;

            if (qhigh == 0)
            {
                qlow++;
            }
        }
        return new LongLong(qhigh, qlow);
    }
    public override int Compare(LongLong a, LongLong b)
    {
        if (a._high > b._high)
        {
            return 1;
        }
        else if (a._high < b._high)
        {
            return -1;
        }
        else
        {
            if (a._low > b._low)
            {
                return 1;
            }
            else if (a._low < b._low)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }

    public override void ToString()
    {
        Console.WriteLine($"{_high} : {_low}");
    }
}
