clear;clc

x = 10;
y = 10;
z = 10;
%%%
L = 5;
W = 5;
H = 4;
[a, b, c] = meshgrid([0 1]);
p = alphaShape(L*a(:) - (L-x), W*b(:) - (W-y), H*c(:) - (0-z));
plot(p, 'edgecolor', 'none')
xlabel('x');
ylabel('y');
zlabel('z');
direction = [1 0 0];
%rotate(p,direction,25)
camlight
grid on;
hold on;

axis([0, 21, 0, 21, 0, 20]);


