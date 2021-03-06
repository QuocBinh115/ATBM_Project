grant select on dba_users to CSYT_Admin;
create or replace procedure CSYT_Admin.ShowAllUser (CUR out SYS_REFCURSOR)
as

    BEGIN
        Open CUR for SELECT USERNAME FROM dba_users where USERNAME like 'C##CSYT%';

    END;
    /
grant select on dba_roles to CSYT_Admin;
/
create or replace procedure CSYT_Admin.ShowAllRole (CUR out SYS_REFCURSOR)
as

    BEGIN
        Open CUR for SELECT ROLE FROM dba_roles where ROLE like 'C##CSYT_ROLE_%';

    END;
    /