using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
//ghdrl95
/*
* TCP 서버  - 파일 데이터 
*/
namespace sever
{
    sealed class AllowAllAssemblyVersionsDeserializationBinder : SerializationBinder
    {
        public override Type BindToType(string assemblyName, string typeName)
        {
            Type typeToDeserialize = null;

            String currentAssembly = Assembly.GetExecutingAssembly().FullName;

            // In this case we are always using the current assembly
            assemblyName = currentAssembly;

            // Get the type using the typeName and assemblyName
            typeToDeserialize = Type.GetType(String.Format("{0}, {1}",
                typeName, assemblyName));

            return typeToDeserialize;
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            //서버 생성
            TcpListener listener = new TcpListener(10000); // socket생성
            //클라이언트 연결 허용
            listener.Start();
            //클라이언트 연결
            TcpClient client = listener.AcceptTcpClient(); //accept();
            NetworkStream stream = client.GetStream();
            //using(NetworkStream stream = client.GetStream()){}
            //파일 데이터를 저장할 파일 스트림 객체 생성

            //수신 받을 데이터를 파일 스트림에 저장

            //파일 닫기

            //클라이언트 연결 종료
            stream.Close();
            client.Close();
            //서버 종료
            listener.Stop();

        }
    }
}
