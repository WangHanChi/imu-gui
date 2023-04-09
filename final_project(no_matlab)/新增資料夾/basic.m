% % xyz方向边长
% a=1;
% b=1;
% c=1; 
% 
% % 8个顶点xyz坐标
% verts=[0 0 0;
%        a 0 0;
%        a b 0;
%        0 b 0;
%        0 0 c;
%        a 0 c;
%        a b c;
%        0 b c];
% 
% % 6个面顶点编号
% faces=[1 2 3 4;
%        1 2 6 5;
%        2 3 7 6;
%        3 4 8 7;
%        4 1 5 8;
%        5 6 7 8];
% 
% % 作图
% patch('Faces',faces,'Vertices',verts,'Facecolor','red')
% axis equal
% view(3);
% grid on;
% axis([-0.5 1.5 -0.5 1.5 -0.5 1.5])

%%
function Cube(gy_x, gy_y, gy_z)
% xyz方向边长
a=1.5;
b=1;
c=0.3; 

% 8个顶点xyz坐标
verts=[0 0 0;
       a 0 0;
       a b 0;
       0 b 0;
       0 0 c;
       a 0 c;
       a b c;
       0 b c];

% 6个面顶点编号
faces=[1 2 3 4;
       1 2 6 5;
       2 3 7 6;
       3 4 8 7;
       4 1 5 8;
       5 6 7 8];

% 作图
patch('Faces',faces,'Vertices',verts,'Facecolor','red')
axis equal
view(3);
grid on;
axis([-0.5 1.5 -0.5 1.5 -0.5 1.5])
end


