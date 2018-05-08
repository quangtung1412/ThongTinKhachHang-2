USE CRM;
GO
alter PROCEDURE DBO.DV_INSERT_TIEPQUY
@ngaydenghi Date,
@macn nvarchar(10),
@manv nvarchar(50),
@atmid nvarchar(10),
@soto50 int,
@soto100 int,
@soto200 int,
@soto500 int
as
insert into tiepquy
(
ngaydenghi,
macn,
manv,
atmid,
st50,
st100,
st200,
st500
)
values
(
@ngaydenghi,
@macn,
@manv,
@atmid,
@soto50,
@soto100,
@soto200,
@soto500
)
 