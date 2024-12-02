Окно авторизации

<Window x:Class="GoodProject.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:GoodProject"
        mc:Ignorable="d"
        Title="Главное окно" Height="300" MinHeight="300" MaxHeight="700" Width="300" MinWidth="300" MaxWidth="600">
    <DockPanel>
        <Button Click="btnEnter_Click" Name="btnEnter" Content="Войти" DockPanel.Dock="Bottom"></Button>
        <TextBlock DockPanel.Dock="Top" HorizontalAlignment="Center" Text="Авторизация" />
        <StackPanel Orientation="Vertical" HorizontalAlignment="Center" VerticalAlignment="Center">
            <StackPanel Orientation="Horizontal" HorizontalAlignment="Right">
                <TextBlock Text="Логин:"></TextBlock>
                <TextBox x:Name="LoginBox"></TextBox>
            </StackPanel>
            <StackPanel Orientation="Horizontal" HorizontalAlignment="Right">
                <TextBlock Text="Пароль:"></TextBlock>
                <PasswordBox x:Name="PassBox"></PasswordBox>
            </StackPanel>
        </StackPanel>
    </DockPanel>
</Window>

App.xaml

<Application x:Class="GoodProject.App"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:local="clr-namespace:GoodProject"
             StartupUri="MainWindow.xaml">
    <Application.Resources>
        <Style TargetType="TextBox">
            <Setter Property="FontSize" Value="17"/>
            <Setter Property="Width" Value="180"/>
            <Setter Property="Height" Value="45"/>
            <Setter Property="HorizontalAlignment" Value="Right"/>
            <Setter Property="VerticalContentAlignment" Value="Center"/>
        </Style>
            <Style TargetType="ComboBox">
            <Setter Property="Margin" Value="10"/>
            <Setter Property="FontSize" Value="17"/>
            <Setter Property="Width" Value="180"/>
            <Setter Property="Height" Value="45"/>
            <Setter Property="VerticalContentAlignment" Value="Center"/>
        </Style>
        <Style TargetType="TextBlock">
            <Setter Property="Margin" Value="10"/>
            <Setter Property="FontSize" Value="17"/>
            <Setter Property="VerticalAlignment" Value="Center"/>
            <Setter Property="HorizontalAlignment" Value="Right"/>
        </Style>
        <Style TargetType="TextBlock" x:Key="TextBlockBold">
            <Setter Property="Margin" Value="10"/>
            <Setter Property="FontSize" Value="20"/>
            <Setter Property="FontWeight" Value="Bold"/>
            <Setter Property="VerticalAlignment" Value="Center"/>
            <Setter Property="HorizontalAlignment" Value="Right"/>
        </Style>
        <Style TargetType="PasswordBox">
            <Setter Property="FontSize" Value="17"/>
            <Setter Property="Width" Value="180"/>
            <Setter Property="Height" Value="45"/>
            <Setter Property="VerticalContentAlignment" Value="Center"/>
            <Setter Property="HorizontalAlignment" Value="Right"/>
        </Style>
        <Style TargetType="Button">
            <Setter Property="Margin" Value="10"/>
            <Setter Property="FontSize" Value="17"/>
            <Setter Property="VerticalContentAlignment" Value="Center"/>
            <Setter Property="Width" Value="180"/>
            <Setter Property="Height" Value="45"/>
            <Setter Property="BorderThickness" Value="0"/>
        </Style>
        <Style TargetType="StackPanel">
            <Setter Property="Margin" Value="5"/>
        </Style>
    </Application.Resources>
</Application>

Окно вывода данных

<Window x:Class="GoodProject.WinOrg"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:GoodProject"
        mc:Ignorable="d"
        Title="Окно организатора" Height="450" MinHeight="450" MaxHeight="500" Width="800" MinWidth="800" MaxWidth="900">
    <DockPanel>
        <Button Click="backButton_Click" Content="Назад" DockPanel.Dock="Bottom" Name="backButton"></Button>
        <StackPanel Orientation="Vertical">
            <TextBlock HorizontalAlignment="Center" Text="Окно организатора" Style="{StaticResource TextBlockBold}"></TextBlock>
            <TextBlock HorizontalAlignment="Center" Text="Пользователи"></TextBlock>
            <DataGrid IsReadOnly="True" AutoGenerateColumns="False" x:Name="userGrid">
                <DataGrid.Columns>
                    <DataGridTextColumn Width="*" Header="Логин" Binding="{Binding numUser}"></DataGridTextColumn>
                    <DataGridTextColumn Width="*" Header="Пароль" Binding="{Binding password}"></DataGridTextColumn>
                </DataGrid.Columns>
            </DataGrid>
        </StackPanel>
    </DockPanel>
</Window>

Код авторизации

using System;
using System.Linq;
using System.Windows;

namespace GoodProject
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            Auth(LoginBox.Text, PassBox.Password);
        }
        public int Auth(string login, string password)
        {
            int log;
            try
            {
                if (login.Trim(' ') == String.Empty)
                {
                    MessageBox.Show("Поле для ввода логина пусто. Введите логин!");
                    return 0;
                }
                if (password.Trim(' ') == String.Empty)
                {
                    MessageBox.Show("Поле для ввода пароля пусто. Введите пароль!");
                    return 0;
                }
                try
                {
                    log = int.Parse(login);
                }
                catch
                {
                    MessageBox.Show("Логин введен неверно. Введите верный логин!");
                    return 0;
                }

                //сюда добавить свой контекст данных вместо UserDBEntities
                using (UserDBEntities db = new UserDBEntities())
                {
                    var users = db.Users.FirstOrDefault(u => u.numUser == log && u.password == password);
                    if (users != null)
                    {
                        //if (users.Role.Any(u => u.Role1 == "организатор"))
                        //{
                            //сюда добавить свое окно вместо WinOrg
                            WinOrg org = new WinOrg();
                            org.Show();
                            this.Close();
                            MessageBox.Show("Успешно");
                            return 1;
                        //}
                    }
                    else 
                    { 
                        MessageBox.Show("Пароль введен неверно. Введите верный пароль!");
                        return 0;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка");
                return 0;
            }
        }
    }
}


Код вывода данных

using System.Linq;
using System.Windows;

namespace GoodProject
{
    public partial class WinOrg : Window
    {
        public WinOrg()
        {
            using(var db = new UserDBEntities())
            {
                InitializeComponent();
                userGrid.ItemsSource = db.Users.ToList();
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}

Тестирование

using GoodProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestGoodProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            using(UserDBEntities db =  new UserDBEntities())
            {
                MainWindow main = new MainWindow();
                int real = main.Auth("1", "pass1");
                int expect = 1;
                Assert.AreEqual(expect, real);
            }
        }
        [TestMethod]
        public void TestMethod2()
        {
            using (UserDBEntities db = new UserDBEntities())
            {
                MainWindow main = new MainWindow();
                int real = main.Auth("1", "nepass1");
                int expect = 0;
                Assert.AreEqual(expect, real);
            }
        }
        [TestMethod]
        public void TestMethod3()
        {
            using (UserDBEntities db = new UserDBEntities())
            {
                MainWindow main = new MainWindow();
                int real = main.Auth("ne1", "pass1");
                int expect = 0;
                Assert.AreEqual(expect, real);
            }
        }
        [TestMethod]
        public void TestMethod4()
        {
            using (UserDBEntities db = new UserDBEntities())
            {
                MainWindow main = new MainWindow();
                int real = main.Auth("", "pass1");
                int expect = 0;
                Assert.AreEqual(expect, real);
            }
        }
        [TestMethod]
        public void TestMethod5()
        {
            using (UserDBEntities db = new UserDBEntities())
            {
                MainWindow main = new MainWindow();
                int real = main.Auth("1", "");
                int expect = 0;
                Assert.AreEqual(expect, real);
            }
        }
    }
}

Прочее

1. Алгоритм
начальный и конечный узел - овальные, нужно писать н-о и к-ц или начало и конец
у декомпозии -круглые, писать ничего не надо
подписи у блоков повторяться не должны (два раза данные о бд не пишем)
у таблицы - Номер, Название, Предыдущие действия, Исполнитель

2. Руководства пользователя или программиста - правильно оформить титульник, поменять файлы
Модификация - какие изменения можно внести
Отладка - расписать, что отлаживала (текстом)
 
4. БД 
назвать правильными названия (только транслит или только на англ)
Размеры полей правильные (если фио – то не может быть 500)
Каскадное удаление
NULL/NOT NULL
резервная копия
Хранимые процедуры 3+ штуки (проверить наличие и при подключении бд выбирать и их)
CREATE PROCEDURE GetAllUsers AS
BEGIN
    SELECT * FROM Users (поменять на свою таблицу);
END
Словарь данных - Key, Field Name, Data Type, Required (если надо - у, если нет - n), Notes
Сделать еще раз копию с процедурами

5. Контекст данных
        private static prakticEntities context; 
 
        public static prakticEntities GetContext() 
        { 
            if (context == null) 
                context = new prakticEntities(); 
            return context; 
        } 

6. Тест
Протокол тестирования - Название тестового сценария: Тестирование функции авторизации.
Тип тестирования: модульное.
Тестируемые данные: Функция авторизации. 
Отчет по результатам проведения тестирования представлен в таблице.
Название   Описание   Входные данные  Выходные данные Удачное/неудачное Предложения

Успешная авторизация
  Ввод корректных данных для входа   Корректный логин и пароль.  Сообщение об успешном тестировании  
Некорректный пароль
  Ввод некорректного пароля   Корректный логин и некорректный пароль  Сообщение об ошибке при попытке авторизации.
Несуществующий логин  
Ввод некорректного логина  Корректный пароль и некорректный логин  Сообщение об ошибке при попытке авторизации.
Пустой ввод логина  Ввод только пароля  Корректный пароль  Сообщение о необходимости заполнения поля.
Пустой ввод пароля  Ввод только логина  Корректный логин   Сообщение о необходимости заполнения поля.

7. Не забыть
— назвать кнопки
— удалить ненужные библиотеки
— удалить комментирование кода
- try/catch

8. Вывод картинки
using (ConfEntities db = new ConfEntities())
            {
                var query =
                from ev in db.eventing
                join evfl in db.event_type_field on ev.id_event equals evfl.id_event
                join fl in db.field on evfl.field.id_field equals fl.id_field
                select new { Номер = ev.id_event, Название = ev.name_event, Направление = fl.name_field, Дата = ev.date_start };
                var formattedQuery = query.ToList().Select(item => new
                {
                    Путь = $"/Мероприятия/{item.Номер}.jpg",
                    Название2 = item.Название,
                    Направление2 = item.Направление,
                    Дата2 = ((DateTime)item.Дата).ToString("dd/MM/yy")
                });

                DataGridTemplateColumn imageColumn = new DataGridTemplateColumn();
                DataGridTextColumn data1 = new DataGridTextColumn();
                DataGridTextColumn data2 = new DataGridTextColumn();
                DataGridTextColumn data3 = new DataGridTextColumn();
                imageColumn.Header = "Логотип";
                imageColumn.Width = 90;
                FrameworkElementFactory imageFactory = new FrameworkElementFactory(typeof(Image));
                imageFactory.SetBinding(Image.SourceProperty, new Binding("Путь"));
                imageFactory.SetValue(Image.StretchProperty, System.Windows.Media.Stretch.Fill);
                DataTemplate imageTemplate = new DataTemplate();
                imageTemplate.VisualTree = imageFactory;
                imageColumn.CellTemplate = imageTemplate;
                data1.Binding = new Binding("Название2");
                data2.Binding = new Binding("Направление2");
                data3.Binding = new Binding("Дата2");
                event1.RowHeight = 60;
                event1.Columns.Add(imageColumn);
                event1.Columns.Add(data1);
                event1.Columns.Add(data2);
                event1.Columns.Add(data3);
                event1.ItemsSource = formattedQuery;
            }

9. QR-код
public MainWindow()
{
    InitializeComponent();
    GenerateQRCode();
}

private void GenerateQRCode()
{
    string text = "Hello, World!"; // Текст, который будет закодирован в QR-коде

    QRCodeGenerator qrGenerator = new QRCodeGenerator();
    QRCodeData qrCodeData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
    QRCode qrCode = new QRCode(qrCodeData);
    System.Drawing.Bitmap qrCodeImageBitmap = qrCode.GetGraphic(20); // Размер QR-кода

    System.Windows.Media.Imaging.BitmapSource qrCodeImageSource =
        System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
            qrCodeImageBitmap.GetHbitmap(),
            IntPtr.Zero,
            Int32Rect.Empty,
            System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());

    qrCodeImage.Source = qrCodeImageSource;
}

<Image x:Name="qrCodeImage" HorizontalAlignment="Center" VerticalAlignment="Center"/><Image x:Name="qrCodeImage" HorizontalAlignment="Center" VerticalAlignment="Center"/>