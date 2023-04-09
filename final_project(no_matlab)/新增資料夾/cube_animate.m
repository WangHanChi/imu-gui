%立方体绕x轴旋转一定的角度，theta为要旋转的角度（单位：弧度）
function cube_animate(theta_x, theta_y, theta_z)
step = 20;%动画50帧
alpha1 = linspace(0,theta_y,step);%每一帧旋转的角度
alpha2 = linspace(0,theta_x,step);
alpha3 = linspace(0,theta_z,step);
global v;

v = [1,1,1;-1,1,1; -1,-1,1;1,-1,1;
    1,1,-1;-1,1,-1;-1,-1,-1; 1,-1,-1]; 

f = [1,2,3,4;
     5,6,7,8;
     1,4,8,5;
     1,2,6,5;
     3,2,6,7;
     3,4,8,7];

global V;
global R;


    for j = 1:step
         R = roty(alpha2(j));%旋转矩阵，调用rotx（）函数(Robotics Toolbox for MATLAB，作者Peter Corke)
         V = R*v';
         clf;
         patch('Faces',f,'Vertices',V','FaceColor','red');%绘制立方体
         view(3);%视角
         axis([-3,3,-3,3,-3,3]);%坐标系范围
         drawnow;
         
         %
         R = rotx(alpha1(j));%旋转矩阵，调用rotx（）函数(Robotics Toolbox for MATLAB，作者Peter Corke)
         V = R*v';
         clf;
         patch('Faces',f,'Vertices',V','FaceColor','red');%绘制立方体
         view(3);%视角
         axis([-3,3,-3,3,-3,3]);%坐标系范围
         drawnow;
    end
     disp(V);
     disp(V');
     disp(v);
     disp(v');
disp('----------------');
    %
%     for j = 1:step
%          disp(V);
%          disp(V');
%          disp(v);
%          disp(v');
%          R = roty(alpha2(j));%旋转矩阵，调用rotx（）函数(Robotics Toolbox for MATLAB，作者Peter Corke)
%          V = R*v';
%          
%          clf;
%          patch('Faces',f,'Vertices',V','FaceColor','blue');%绘制立方体
%          view(3);%视角
%          axis([-3,3,-3,3,-3,3]);%坐标系范围
%          drawnow;
%     end
xlabel('X');
ylabel('Y');
zlabel('Z');
end

