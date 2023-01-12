using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singly_linked_list
{
    class Node
    {
        public int idplg;
        public string Nama;
        public string Jenis;
        public int HP;
        public Node next;
    }
    class List
    {
        Node START;
        public List()
        {
            START = null;
        }
        //Method untuk menambahkan sebuah node ke dalam list

        public void addNode()
        {
            int ID;
            string nama;
            string Jkp;
            int Nohp;
            Console.WriteLine("\nMasukan ID Pelanggan: ");
            ID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nMasukan nama Pelanggan: ");
            nama = Console.ReadLine();
            Console.WriteLine("\nJenis Kelamin P/L: ");
            Jkp = Console.ReadLine();
            Console.WriteLine("\nMasukkan nomer HP: ");
            Nohp = Convert.ToInt32(Console.ReadLine());
            Node nodeBaru = new Node();
            nodeBaru.idplg = ID;
            nodeBaru.Nama = nama;
            nodeBaru.Jenis = Jkp;
            nodeBaru.HP = Nohp;

            //Node ditambahkan sebagai node pertama 
            if (START == null || ID <= START.idplg)
            {
                if ((START != null) && (ID == START.idplg))
                {
                    Console.WriteLine("\nId pelanggan sama tidak diizinkan ");
                }
                nodeBaru.next = START;
                START = nodeBaru;
                return;
            }
            //Menemukan lokasi node baru didalam list
            Node previous, currrent;
            previous = START;
            currrent = START;

            while ((currrent != null) && (ID >= currrent.idplg))
            {
                if (ID == currrent.idplg)
                {
                    Console.WriteLine("\nId pegawai sama tidak diizinkan");
                    return;
                }
                previous = currrent;
                currrent = currrent.next;
            }
            nodeBaru.next = currrent;
            previous.next = nodeBaru;
        }
        //Method untuk menghapus node tertentu didalam list
        public bool delNode(string nama)
        {
            Node previous, current;
            previous = current = null;
            //check apakah node yang dimaksud ada di dalam list atau tidak
            if (Search(nama, ref previous, ref current) == false)
                return false;
            previous.next = current.next;
            if (current == START)

                START = START.next;
            return true;

        }
        //Method untuk meng-check apakah node yang dimaksud ada didalam list atau tidak
        public bool Search(string nama, ref Node previous, ref Node current)
        {
            previous = current;
            while ((current != null) && (nama == current.Nama))
            {
                previous = current;
                current = current.next;
            }
            if (current == null)
                return (false);
            else
                return (true);


        }
        //Method untuk treverse /mengunjungi dan membaca isi list
        public void traverse()
        {
            if (listEmpty())
                Console.WriteLine("\nList kosong: ");
            else
            {
                Console.WriteLine("\nData di dalam list adalah: ");
                Node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                    Console.Write(currentNode.idplg + "" + currentNode.Nama + "" + currentNode.Jenis + "" + currentNode.HP + "\n");
                Console.WriteLine();
            }
        }
        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            List obj = new List();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("1. Menambah data kedalam list");
                    Console.WriteLine("2. Menghapus data dari dalam list");
                    Console.WriteLine("3. Melihat semua data didalam list");
                    Console.WriteLine("4. Mencari sebuah data didalam list");
                    Console.WriteLine("5. Exit");
                    Console.Write("\nMasukkan Pilihan Anda (1-5): ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.addNode();
                            }
                            break;
                        case '2':
                            {
                                if (obj.listEmpty()) ;
                                {
                                    Console.WriteLine("\nList Kosong");
                                    break;
                                }
                                Console.Write("\nMasukkan nama mahasiswa yang akan dihapus: ");
                                string nama = Convert.ToString(Console.ReadLine());
                                Console.WriteLine();
                                if (obj.delNode(nama) == false)
                                    Console.WriteLine("\nData tidak ditemukan.");
                                else
                                    Console.WriteLine("Data dengan nama pelanggan " + nama + "dihapus");
                            }
                            break;
                        case '3':
                            {
                                obj.traverse();
                            }
                            break;
                        case '4':
                            {
                                if (obj.listEmpty())
                                {
                                    Console.WriteLine("\nList Kosong !");
                                    break;
                                }
                                Node provious, current;
                                provious = current = null;
                                Console.Write("\nMasukkan Nama pelanggan yang akan dicari: ");
                                string nama = Convert.ToString(Console.ReadLine());
                                if (obj.Search(nama, ref provious, ref current) == false)
                                    Console.WriteLine("\nData tidak ditemukan.");
                                else
                                {
                                    Console.WriteLine("\nData ketemu");
                                    Console.WriteLine("\nId pelanggan: " + current.idplg);
                                    Console.WriteLine("\nNama: " + current.Nama);
                                    Console.WriteLine("\nJenis kelamin: " + current.Jenis);
                                    Console.WriteLine("\nNomer Hp: " + current.HP);
                                }
                            }
                            break;
                        case '5':
                            return;
                        default:
                            {
                                Console.WriteLine("\nPilihan tidak valid");
                                break;
                            }

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("\nCheck data yang anda masukkan.");
                }
            }
        }
    }
}


//nomor 2: Saya menggunakan algoritma single linked list karena terdapat method traverse, addnode, dan list empety
//. jadi algoritma tersebut menurut saya sesuai apa yang diinginkan dalam cerita
//nomor 3: ascending dan descending
//nomor 4: jika menggunakan link list untuk membuat list beberapa data sedangkan array hanya mengurutkan saja
//nomor 5;
//  A. 
//  B. menggunakan inorder
