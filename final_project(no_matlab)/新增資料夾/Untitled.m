[x,y,z]=meshgrid([-1 1]);
h=slice(x,y,z,z,[-1 1],[-1 1],[-1 1]);
hold on
hr=slice(x,y,z,z,[-1 1],[-1 1],[-1 1]);
hold off
col=jet(6);
% for i=1:length(h)
set(h(i),'LineStyle','--','FaceAlpha',0.9,'FaceColor',col(mod(i-1,6)+1,:));
% set(hr(i),'FaceColor',col(mod(i-1,6)+1,:));
% end
% p=[3 1 0];  % a point on the axis
% direct=[0 0 1];  % direction，set as you will
% theta=90/2;    % rotation angle, set as you pleased
% rotate(hr,direct,rad2deg(theta),p)

%
p=[3 1 0];  % a point on the axis
direct=[1 0 0];  % direction，set as you will
theta=90/2;    % rotation angle, set as you pleased
rotate(hr,direct,rad2deg(theta),p)

% line([p(1) p(1)+direct(1)],[p(2) p(2)+direct(2)],[p(3) p(3)+direct(3)],'color','k','linewidth',2)
% line(p(1)+direct(1), p(2)+direct(2), p(3)+direct(3),'Marker','^','MarkerFace','k')
xlabel('X');
ylabel('Y');
zlabel('Z');
axis equal

