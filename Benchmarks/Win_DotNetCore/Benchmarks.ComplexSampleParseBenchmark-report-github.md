``` ini

BenchmarkDotNet=v0.11.3, OS=Windows 10.0.17134.523 (1803/April2018Update/Redstone4)
AMD Phenom(tm) II X4 955 Processor, 1 CPU, 4 logical and 4 physical cores
Frequency=3146050 Hz, Resolution=317.8589 ns, Timer=TSC
.NET Core SDK=2.2.102
  [Host]     : .NET Core 2.2.1 (CoreCLR 4.6.27207.03, CoreFX 4.6.27207.03), 64bit RyuJIT
  DefaultJob : .NET Core 2.2.1 (CoreCLR 4.6.27207.03, CoreFX 4.6.27207.03), 64bit RyuJIT


```
|    Method |      Mean |     Error |    StdDev | Gen 0/1k Op | Gen 1/1k Op | Gen 2/1k Op | Allocated Memory/Op |
|---------- |----------:|----------:|----------:|------------:|------------:|------------:|--------------------:|
| SystemXml | 11.102 us | 0.2196 us | 0.2055 us |     13.3209 |           - |           - |            13.72 KB |
|   FastXml |  1.800 us | 0.0312 us | 0.0292 us |      1.3943 |           - |           - |             1.43 KB |
|   NanoXml |  1.576 us | 0.0275 us | 0.0257 us |      1.3332 |           - |           - |             1.37 KB |
