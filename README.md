# Приложение «Помощник кладовщика» WarehouseAssistant

Данное приложение предназначено для перемещения товаров между складами компании, получения товаров на склад извне. 
Существует возможность создания нового перемещения, удаления существующего перемещения, просмотра списка товаров, складов и остатков на складах на заданное время.

## Стек технологий

* Backend: ASP.NET Core Web API
* Frontend: Vue.js (+ vuex, axios, vue-router, vuepic/vue-datepicker)
* DB: MSSQL
* ORM: Entity Framework
* Тесты: XUnit

## Обзор возможностей

### Начальная страница

На начальной странице отображена некоторая информация о проекте.

![1](/docs/img/Home.png)

### Страница «Склады»
На данной странице выводится список всех доступных складов.

![2](/docs/img/Storages.png)

### Страница «Номенклатуры»
На данной странице выводится список всех доступных номенклатур.

![3](/docs/img/Items.png)

### Страница «Перемещения»
На данной странице выводится список всех перемещений. 

При нажатии на кнопку *"Удалить"* на выбранной строке запись удаляется.

![4](/docs/img/Transactions.png)

При нажатии на кнопку *"Добавить"* открывается форма добавления нового перемещения:

![5](/docs/img/AddTransaction.png)

Форма заполняется посредством выбора номенклатуры из выпадающего списка, количества товаров в поле ввода, выбора пункта отправления
(при выборе чек-бокса *"Извне"* данный выпадающий список отключается, перемещение считается выполненным извне на выбранный склад)
и пункта назначения посредством выпадающих списков.

### Страница «Остаток»
На данной странице выводится список всех оставшихся товаров для выбранного склада на указанную дату.
![6](/docs/img/Stocks1.png)

При нажатии на поле выбора даты появляется DatePicker:
![7](/docs/img/Stocks2.png)

После выбора даты необходимо указать склад, по которому будет производиться расчет остатков с помощью выпадающего списка:
![8](/docs/img/Stocks3.png)

После нажатия на кнопку *"Показать"* появляется таблица со всеми доступными товарами:
![9](/docs/img/Stocks4.png)

## Необходимые доработки:
* Добавление документации в коде
* Обработка исключений
* Расчет допустимого количества товаров при создании перемещения (со склада не может быть перемещено товаров больше, чем там есть на данный момент)
* Расход со склада при создании нового перемещения
* Выбор нескольких ТМЦ при создании перемещения
