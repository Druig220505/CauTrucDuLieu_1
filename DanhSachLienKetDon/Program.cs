using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanhSachLienKetDon
{
    class Node
    {
        private int info;
        private Node next;
        public Node(int x)
        {
            info = x;
            next = null;
        }
        public int Info
        {
            set { this.info = value; }
            get { return info; }
        }
        public Node Next
        {
            set { this.next = value; }
            get { return next; }
        }       
    }
    //Định nghĩa cấu trúc DSLK đơn
    class  SingleLinkList
    {
        private Node Head;
        public SingleLinkList()
        {
            Head = null;
        }
        //Các thao tác trên danh sách LKD
        //Thêm nút mới vào đầu xâu
        public void AddHead(int x)
        {
            Node p = new Node(x);//cập nhật nút mới
            p.Next = Head;
            Head = p;
        }       
        public void AddLast(int x)
        {
            Node p = new Node(x);//cập nhật nút mới
            if (Head == null)
            {
                Head = p;
            }
            else
            {
                Node q = Head;
                while (q.Next != null) { q = q.Next; }
                q.Next = p;
            }    
        }
        //xoá nút đầu
        public void DeleteHead()
        {
            if(Head!=null)
            {
                Node p = Head;
                Head = Head.Next;
                p.Next = null;
            }    
        }
        //xoá nút sau
        public void DeleteLast()
        {
            if(Head!=null)
            {
                Node p = Head;
                Node q = null;
                while(p.Next!=null)
                    //duyệt ds để tìm nút cuối
                {
                    q = p;
                    p = p.Next;
                }
                q.Next = null;
            }    
        }
        //pt xoá nút có giá trị x
        public void DeleteNode(int x)
        {
            if(Head != null)
            {
                Node p = Head;
                Node q = null;
                //duyệt ds để tìm giá trị x cần xoá
                while(p!=null && p.Info!=x)
                {
                    q = p;
                    p = p.Next;
                }
                //xoá nút P
                if(p!=null)
                {
                    if (p == Head)
                        DeleteHead();
                    else
                    {
                        q.Next = p.Next;
                        p.Next = null;
                    }    
                }    
            }    
        }
        public Node findMax()
        {
            Node max = Head;
            Node p = Head.Next;
            while(p!=null)
            {
                if(p.Info>max.Info)
                {
                    max = p;
                }
                p = p.Next;
            }
            return max;
        }
        public float Avg()
        {
            float sum = 0;
            int count = 0;
            Node p = Head;
            while(p!=null)
            {
                sum += p.Info;
                count++;
                p = p.Next;
            }
            return sum / count;
        }
        //pt duyệt danh sách(xuất)
        public void ProcessList()
        {
            Node p = Head;
            while (p != null)
            {
                Console.Write($"{p.Info}    ");//Xuất giá trị của nút
                p = p.Next;
            }
        }
    }
    


    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            SingleLinkList l = new SingleLinkList();
            //l.AddHead(5);
            //l.AddHead(3);
            //l.AddLast(9);
            NhapDanhSach(l);
            Console.WriteLine("Danh sách liên kết:");
            l.ProcessList();

            l.DeleteHead();
            Console.WriteLine("\n Danh sách liên kết sau khi xoá nút đầu:");
            l.ProcessList();

            l.DeleteLast();
            Console.WriteLine("\n Danh sách liên kết sau khi xoá nút sau:");
            l.ProcessList();

            Console.Write("\n Nhập giá trị x cần xoá:");
            int x = int.Parse(Console.ReadLine());
            l.DeleteNode(x);
            Console.WriteLine("\n Danh sách liên kết sau khi xoá nút có giá trị x:");
            l.ProcessList();

            Node max = l.findMax();
            Console.WriteLine($"\n Nút có giá trị lớn nhất:{max.Info}");

            float tbc = l.Avg();
            Console.WriteLine($"\n Giá trị trung bình các nút:{tbc}");

            Console.ReadLine();
        }
        static void NhapDanhSach(SingleLinkList l)
        {
            string chon = "y";
            int x;
            while (chon != "n")
            {
                Console.Write("Nhập giá trị nút: ");
                x = int.Parse(Console.ReadLine());
                l.AddLast(x);
                Console.Write("Tiếp tục (y/n)?");
                chon = Console.ReadLine();
            }
        }
    }
    
}
