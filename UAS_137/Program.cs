using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS_137
{
    class Node
    {
        public int idPelanggan;
        public string name;
        public string jenisKelamin;
        public int nomorTelepon;
        public Node next;
        public Node prev;
    }
    class SingleList
    {
        Node LAST;

        public SingleList()
        {
            LAST = null;
        }

        public void addNode()
        {
            int idpelanggan;
            string nama;
            string jeniskelamin;
            int notelpon;

            Console.Write("\nMasukan Id Pelanggan : ");
            idpelanggan = Convert.ToInt32(Console.ReadLine());

            Console.Write("\nMasukan Nama Pelanggan : ");
            nama = Console.ReadLine();

            Console.Write("\nMasukan Jenis Kelamin : ");
            jeniskelamin = Console.ReadLine();

            Console.Write("\nMasukan Nomor Telepon : ");
            notelpon = Convert.ToInt32(Console.ReadLine());

            Node newnode = new Node();
            newnode.idPelanggan = idpelanggan;
            newnode.name = nama;
            newnode.jenisKelamin = jeniskelamin;
            newnode.nomorTelepon = notelpon;

            if (LAST == null || idpelanggan <= LAST.idPelanggan)
            {
                newnode.next = LAST;
                LAST = newnode;
                return;
            }

            Node previous, current;
            for (current = previous = LAST; current != null && idpelanggan >= current.idPelanggan; previous = current, current = current.next) 

            newnode.next = current;
            newnode.prev = previous;

            if (current == null)
            {
                newnode.next = null;
                previous.next = newnode;
                return;
            }
            newnode.next = current;
            previous.next = newnode;
        }
        public bool search(string nama, ref Node previous, ref Node current)
        {
            previous = LAST;
            current = LAST;

            while ((current != null) && (nama != current.name))
            {
                previous = current;
                current = current.next;
            }

            if (current == null)
                return (false);
            else
                return (true);
        }

        public bool listEmpty()
        {
            if (LAST == null)
                return true;
            else
                return false;
        }

        public void traverse()
        {
            if (listEmpty())
                Console.WriteLine("\nData Tidak Ditemukan.\n");
            else
            {
                Console.WriteLine("\n== DATA PELANGGAN ==\n");
                Node currentNode;
                for (currentNode = LAST; currentNode != null;
                    currentNode = currentNode.next)
                    Console.WriteLine("Id Pelanggan : " + currentNode.idPelanggan + "\nNama Pelanggan : "
                    + currentNode.name + "\nJenis Kelamin : " + currentNode.jenisKelamin + "\nNomor Telepon : " + currentNode.nomorTelepon);
            }
        }

        static void Main(string[] args)
        {
            SingleList obj = new SingleList();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("1. Menambahkan Data Pelanggan ");
                    Console.WriteLine("2. Mencari Data Pelanggan");
                    Console.WriteLine("3. Menampilkan Data Pelaanggan");
                    Console.WriteLine("4. Exit");
                    Console.Write("\nEnter your choice (1-4): ");
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
                                if (obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\nData Tidak Ditemukan ");
                                    break;
                                }
                                Node prev, curr;
                                prev = curr = null;

                                Console.WriteLine("\nMasukan Nama Data Yang Akan Dicari : ");
                                string num = Console.ReadLine();
                                if (obj.search(num, ref prev, ref curr) == false)
                                    Console.WriteLine("\nRecord not faound");
                                else
                                {
                                    Console.WriteLine("\n");
                                    Console.WriteLine("Id Pelanggan: " + curr.idPelanggan);
                                    Console.WriteLine("Nama Pelanggan: " + curr.name);
                                    Console.WriteLine("Jenis Kelamin: " + curr.jenisKelamin);
                                    Console.WriteLine("Nomor Telepon : " + curr.nomorTelepon);

                                }
                            }
                            break;

                        case '3':
                            {
                                obj.traverse();
                            }
                            break;

                        case '4':
                            return;
                        default:
                            {
                                Console.WriteLine("Pilihan Salah");
                                break;
                            }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

    }
}

/*
 
1.Asti merupakan pegawai perusahaan komunikasi. Dia ingin membuat aplikasi buku telepon untuk mempermudah orang lain dalam melihat nomor telepon orang lain, mengurutkan, dan mencari data. Asti mengumpulkan data-data dari perusahaannya dan mendapatkan data tentang nomor telepon pelanggan. Data-data yang Asti kumpulkan sebagian sudah terurut, akan tetapi masih sulit untuk mencari data-data tersebut. Data yang ingin Asti simpan adalah Id Pelanggan, nama pelanggan, Jenis Kelamin Pelanggan, dan nomor telepon pelanggan. Asti berharap aplikasi ini dapat melakukan pencarian berdasarkan nama pelanggan Berdasarkan kasus diatas, buatlah program yang sesuai dengan kebutuhan Asti! (30 Poin)


2.Berdasarkan studi kasus diatas, algoritma apa saja yang anda gunakan? Jelaskan mengapa anda memilih algoritma tersebut(20 Poin)
Jawaban : Algoritma yang digunakan adalah double link,Single list, queue. saya memakai algoritma tersebut untuk refrensi membuat project untuk studi kasus di atas, dan juga karena algoritma-algoritma ini lebih mudah di implementasikan dan juga di ganti beberapa method ke dalam codingan dari studi kasus di atas dan juga data di atas tidak terurut 

3.Algoritma Queue merupakan struktur data dimana satu data dapat ditambakan diakhir disebut …… dan data dihapus dari yang paling terkahir disebut…..? ( 10 Poin)
Jawaban : push dan pup

4.Sebutkan dan jelaskan perbedaan dari array dan linked list dan kapan harus menggunakan tipe data tersebut?
Jawaban : perbedaan dari array dan  linked list adalah linked list menggunakan Node sedangkan array tidak, dan array dapat digunakan jika ingin sebuah data terurut sedangkan linked list bisa digunakan jika sebuah data tidak terurut

5. Perhatikan gambar berikut: (30 poin)
a.Tentukan sibling dari tree diatas?
b. Bagaimana cara membaca struktur pohon di atas? (Pilih salah satu metode yaitu Inorder, Preorder atau Postorder Traversal)
Jawaban :
a. sibling dari tree tersebut adalah (10,10) (15,15) (20,20,20,20) 
b. Postorder Traversal

*/