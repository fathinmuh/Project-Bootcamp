//matriks
int[,] matriks = new int[2, 2];
int[,] m = new int[2, 2];

Console.WriteLine("Masukkan elemen matriks 2x2:");
for (int i = 0; i < 2; i++) {
    string[] baris = Console.ReadLine().Split();
    for (int j = 0; j < 2; j++) {
        matriks[i, j] = int.Parse(baris[j]);
    }
}

Console.WriteLine("Transpos");
for (int i = 0; i < 2; i++) {
    for (int j = 0; j < 2; j++) {
        Console.Write(matriks[j, i] + " ");
    }
    Console.WriteLine();
}

Console.WriteLine("determinan matriks:");
int det = matriks [0,0]*matriks[1,1]-matriks[1,0]*matriks[0,1];
Console.Write(det);

// Console.WriteLine("Invers");
// for (int i = 0; i < 2; i++) {
//     for (int j = 0; j < 2; j++) {
//         m[,]=matriks[0,0];
//         matriks[0,0]=matriks[1,1];
//         matriks[1,0]=-matriks[1,0];
//         matriks[0,1]=-matriks[0,1];
//         matriks[1,1]=m[,]
//         Console.Write(matriks[j, i] + " ");
//     }
//     Console.WriteLine();
// }

// foobar
// Console.WriteLine("n=");
// int x = Convert.ToInt32(Console.ReadLine());
// Console.WriteLine("n=" + x);

// for (int i = 1; i <= x; i++)
// {
//     if (((i % 3) == 0)&&((i % 5)==0 )){
//     Console.Write("foobar, ");
//     }
//     else if ((i % 3) == 0){
//     Console.Write("foo, ");
//     }
//     else if ((i % 5) == 0){
//     Console.Write("bar, ");
//     }
//     else Console.Write(i+", ");
// }

