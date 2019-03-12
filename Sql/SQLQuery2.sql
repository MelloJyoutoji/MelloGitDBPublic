select * from CMS_User

--insert into CMS_User values ('System', 'systemKaun', 'Sys', '13000000000', '', 1)
--insert into CMS_User values ('MelloJyotoji', '2513214', 'Mello', '18008439636', '', 0)
--insert into CMS_User values ('Cyerushii', 'lovelovecyucyu', 'Cyeru', '13269402513', '', 0)
--insert into CMS_User values ('Pedora', 'shinubeshi', 'oresama', '13548685241', '', 0)

select * from CMS_Category
select * from CMS_Article order by ptime desc
select * from CMS_Article where aid >= 1025
select * from CMS_Article where comments != 0
--update CMS_Article set istop = 1 where aid = 1043
select * from CMS_Comment
--delete from CMS_Article where aid = 1042
select * from CMS_Keyword order by stimes desc

--update CMS_Article set ptime = '2015-08-18' where aid = 223
--update CMS_Article set ptime = '2018-08-18' where aid = 201

create view ArticleMain_View
as
	select CMS_Article.*, CMS_User.uname, CMS_User.upwd, CMS_User.nname, CMS_User.mobile, CMS_User.face, CMS_User.admin, CMS_Category.ctitle, CMS_Category.cname, CMS_Category.nav, CMS_Category.navorder, CMS_Category.search from 
	CMS_Article inner join CMS_User on CMS_Article.uid = CMS_User.uid inner join CMS_Category on CMS_Article.cid = CMS_Category.cid
go

create view CommentMain_View
as
	select CMS_Comment.*, CMS_Article.title, CMS_Article.author, CMS_Article.ctime, CMS_Article.ptime, CMS_Article.istop, CMS_Article.state, CMS_Article.hits, CMS_Article.comments, CMS_Article.ahtml, CMS_User.uname, CMS_User.upwd, CMS_User.nname, CMS_User.mobile, CMS_User.face, CMS_User.admin from
	CMS_Comment inner join CMS_Article on CMS_Comment.aid = CMS_Article.aid inner join CMS_User on CMS_Comment.uid = CMS_User.uid
go

----insert into CMS_Article values(1,'从中流砥柱到背锅侠 Rookie如何走出困境','DBc00per',1,'2015-01-01',GETDATE(),0,1,100,20,'操作需自行百度根本发生过的')
----insert into CMS_Article values(1,'在Mata当兵前再赢一个冠军','DBc00per',1,'2014-01-01',GETDATE(),0,1,100,20,'操作需自行百度根本发生过的')
----insert into CMS_Article values(1,'解析S9绝食流打法','DBc00per',1,'2010-01-01',GETDATE(),0,1,100,20,'操作v需自行百度根本发生过的')

----insert into CMS_Article values(2,'1月27日JDG在北京主场开幕式图赏与赛后采访','DBc00per',1,'2010-01-01',GETDATE(),0,1,100,20,'操作v需自行百度根本发生过的')
----insert into CMS_Article values(2,'LEC首周两套新阵容 征服者德莱文主宰战场','DBc00per',1,'2008-01-01',GETDATE(),0,1,100,20,'操作v需自行百度根本发生过的')
----insert into CMS_Article values(2,'位置排位上线美服韩服','DBc00per',1,'2017-01-01',GETDATE(),0,1,100,20,'操作v需自行百度根本发生过的')

----insert into CMS_Article values(3,'剑圣野核套路并未死','DBc00per',1,'2011-01-01',GETDATE(),0,1,100,20,'操作v需自行百度根本发生过的')
----insert into CMS_Article values(3,'LCK春季赛宣传片，谁能摘下','DBc00per',1,'2016-01-01',GETDATE(),0,1,100,20,'操作v需自行百度根本发生过的')
----insert into CMS_Article values(3,'鬼斧神工','DBc00per',1,'2010-01-01',GETDATE(),0,1,100,20,'操作v需自行百度根本发生过的')


----insert into CMS_Article values(4,'艾希和蛮子终成眷属 政治婚姻变成真爱','DBc00per',1,'2013-01-01',GETDATE(),0,1,100,20,'操作v需自行百度根本发生过的')
----insert into CMS_Article values(4,'LCK新王取代旧主 GRF全胜夺冠不只空谈','DBc00per',1,'2019-01-01',GETDATE(),0,1,100,20,'操作v需自行百度根本发生过的')
----insert into CMS_Article values(4,'LPL春季赛完整版赛程Ics文件','DBc00per',1,'2010-01-01',GETDATE(),0,1,100,20,'操作v需自行百度根本发生过的')

----insert into CMS_Article values(5,'苹果日历订阅，IG战队比赛赛程','DBc00per',1,'2010-12-01',GETDATE(),0,1,100,20,'操作v需自行百度根本发生过的')
----insert into CMS_Article values(5,'百花齐放才是春-2018冬季赛赛评','DBc00per',1,'2018-09-01',GETDATE(),0,1,100,20,'操作v需自行百度根本发生过的')
----insert into CMS_Article values(5,'话不多说，画一套皮肤支持IG','DBc00per',1,'2012-01-10',GETDATE(),0,1,100,20,'操作v需自行百度根本发生过的')




----insert into CMS_Keyword values('中流砥柱',20,GETDATE(),1)
----insert into CMS_Keyword values('JDG',20,GETDATE(),1)
----insert into CMS_Keyword values('终成眷属',20,GETDATE(),1)
----insert into CMS_Keyword values('IG',20,GETDATE(),1)
----insert into CMS_Keyword values('全胜夺冠',20,GETDATE(),1)
----insert into CMS_Keyword values('鬼斧神工',20,GETDATE(),1)