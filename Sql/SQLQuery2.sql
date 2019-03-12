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

----insert into CMS_Article values(1,'������������������ Rookie����߳�����','DBc00per',1,'2015-01-01',GETDATE(),0,1,100,20,'���������аٶȸ�����������')
----insert into CMS_Article values(1,'��Mata����ǰ��Ӯһ���ھ�','DBc00per',1,'2014-01-01',GETDATE(),0,1,100,20,'���������аٶȸ�����������')
----insert into CMS_Article values(1,'����S9��ʳ����','DBc00per',1,'2010-01-01',GETDATE(),0,1,100,20,'����v�����аٶȸ�����������')

----insert into CMS_Article values(2,'1��27��JDG�ڱ���������Ļʽͼ��������ɷ�','DBc00per',1,'2010-01-01',GETDATE(),0,1,100,20,'����v�����аٶȸ�����������')
----insert into CMS_Article values(2,'LEC�������������� �����ߵ���������ս��','DBc00per',1,'2008-01-01',GETDATE(),0,1,100,20,'����v�����аٶȸ�����������')
----insert into CMS_Article values(2,'λ����λ������������','DBc00per',1,'2017-01-01',GETDATE(),0,1,100,20,'����v�����аٶȸ�����������')

----insert into CMS_Article values(3,'��ʥҰ����·��δ��','DBc00per',1,'2011-01-01',GETDATE(),0,1,100,20,'����v�����аٶȸ�����������')
----insert into CMS_Article values(3,'LCK����������Ƭ��˭��ժ��','DBc00per',1,'2016-01-01',GETDATE(),0,1,100,20,'����v�����аٶȸ�����������')
----insert into CMS_Article values(3,'����','DBc00per',1,'2010-01-01',GETDATE(),0,1,100,20,'����v�����аٶȸ�����������')


----insert into CMS_Article values(4,'��ϣ�������ճɾ��� ���λ�������氮','DBc00per',1,'2013-01-01',GETDATE(),0,1,100,20,'����v�����аٶȸ�����������')
----insert into CMS_Article values(4,'LCK����ȡ������ GRFȫʤ��ڲ�ֻ��̸','DBc00per',1,'2019-01-01',GETDATE(),0,1,100,20,'����v�����аٶȸ�����������')
----insert into CMS_Article values(4,'LPL����������������Ics�ļ�','DBc00per',1,'2010-01-01',GETDATE(),0,1,100,20,'����v�����аٶȸ�����������')

----insert into CMS_Article values(5,'ƻ���������ģ�IGս�ӱ�������','DBc00per',1,'2010-12-01',GETDATE(),0,1,100,20,'����v�����аٶȸ�����������')
----insert into CMS_Article values(5,'�ٻ���Ų��Ǵ�-2018����������','DBc00per',1,'2018-09-01',GETDATE(),0,1,100,20,'����v�����аٶȸ�����������')
----insert into CMS_Article values(5,'������˵����һ��Ƥ��֧��IG','DBc00per',1,'2012-01-10',GETDATE(),0,1,100,20,'����v�����аٶȸ�����������')




----insert into CMS_Keyword values('��������',20,GETDATE(),1)
----insert into CMS_Keyword values('JDG',20,GETDATE(),1)
----insert into CMS_Keyword values('�ճɾ���',20,GETDATE(),1)
----insert into CMS_Keyword values('IG',20,GETDATE(),1)
----insert into CMS_Keyword values('ȫʤ���',20,GETDATE(),1)
----insert into CMS_Keyword values('����',20,GETDATE(),1)