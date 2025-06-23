// A quick and dirty LINQ solution
using System;
using System.ComponentModel.Design;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

void BirthdayCakeCandles(IEnumerable<int> candles)
{
    Console.WriteLine(candles.Count(size => size == candles.Max()));
}

BirthdayCakeCandles([4, 4, 1, 3]);
// The tallest candles are 4. There are 2 candles with this height, so the function should return 2.
BirthdayCakeCandles([1, 1, 1, 1]);
// All candles are the same height, so all are the tallest.
BirthdayCakeCandles([]);
// No candles, so nothing to blow out.