# activitys-api

## 功能
簡易展示活動管理功能與訂票機制

## 用法
1. 於 Mysql 執行 Script\Activitys-sql.sql 建立資料庫&資料表

2. 啟動 DemoApi.sln 執行專案

3. 修改 Startup.cs 中的 options.UseMySql 連線字串為欲連接 MySQL 之參數

4. 啟動 Api 專案

## 使用技術
* language
    * C#
* Framework
    * .NET Core 3.1
* DataBase
    * MySQL 8.0
* EF Core
    * Pomelo.EntityFrameworkCore.MySql v3.1.1

## Api 文件
[PostmanDoc](https://documenter.getpostman.com/view/7077239/SzKWvHuR)

## 待辦事項
- [ ] 加入剩餘票機制
- [ ] 加入票種機制
- [ ] 導入 redis 快取
- [ ] 加入帳號認證
- [ ] 將 sql 連線資訊抽離至 appsettings
- [ ] 包裝成 docker container
- [ ] 建立自動測試