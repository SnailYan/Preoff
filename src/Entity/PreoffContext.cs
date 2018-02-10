using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Preoff.Entity
{
    public partial class PreoffContext : DbContext
    {
        public virtual DbSet<AircTable> AircTable { get; set; }
        public virtual DbSet<AircTypeTable> AircTypeTable { get; set; }
        public virtual DbSet<AirFacTable> AirFacTable { get; set; }
        public virtual DbSet<AirLoadTable> AirLoadTable { get; set; }
        public virtual DbSet<CameraFacTable> CameraFacTable { get; set; }
        public virtual DbSet<CameraTable> CameraTable { get; set; }
        public virtual DbSet<CameraTypeTable> CameraTypeTable { get; set; }
        public virtual DbSet<DivisionTable> DivisionTable { get; set; }
        public virtual DbSet<EquipFacTable> EquipFacTable { get; set; }
        public virtual DbSet<EventTypeTable> EventTypeTable { get; set; }
        public virtual DbSet<EventVideoTable> EventVideoTable { get; set; }
        public virtual DbSet<EvevtImgTable> EvevtImgTable { get; set; }
        public virtual DbSet<EvevtTable> EvevtTable { get; set; }
        public virtual DbSet<ExecTaskTable> ExecTaskTable { get; set; }
        public virtual DbSet<PermissonTable> PermissonTable { get; set; }
        public virtual DbSet<RolePermissionTable> RolePermissionTable { get; set; }
        public virtual DbSet<RoleTable> RoleTable { get; set; }
        public virtual DbSet<StreamVideoServerTable> StreamVideoServerTable { get; set; }
        public virtual DbSet<TaskStateTable> TaskStateTable { get; set; }
        public virtual DbSet<TaskTable> TaskTable { get; set; }
        public virtual DbSet<TaskTypeTable> TaskTypeTable { get; set; }
        public virtual DbSet<TaskUserTable> TaskUserTable { get; set; }
        public virtual DbSet<UnitTable> UnitTable { get; set; }
        public virtual DbSet<UserRoleTable> UserRoleTable { get; set; }
        public virtual DbSet<UserTable> UserTable { get; set; }

        public PreoffContext(DbContextOptions<PreoffContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AircTable>(entity =>
            {
                entity.ToTable("aircTable");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AirDesc)
                    .HasColumnName("air_desc")
                    .HasMaxLength(100);

                entity.Property(e => e.AirFacTableId).HasColumnName("airFacTable_id");

                entity.Property(e => e.AirLoadTableId).HasColumnName("airLoadTable_id");

                entity.Property(e => e.AircTypeTableId).HasColumnName("aircTypeTable_id");

                entity.Property(e => e.RegDate)
                    .HasColumnName("reg_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.SerialNum)
                    .HasColumnName("serial_num")
                    .HasMaxLength(50);

                entity.Property(e => e.UnitTableId).HasColumnName("unitTable_id");

                entity.Property(e => e.UsedDesc)
                    .HasColumnName("used_desc")
                    .HasMaxLength(100);

                entity.HasOne(d => d.AirFacTable)
                    .WithMany(p => p.AircTable)
                    .HasForeignKey(d => d.AirFacTableId)
                    .HasConstraintName("FK_AIRCTABL_REFERENCE_AIRFACTA");

                entity.HasOne(d => d.AirLoadTable)
                    .WithMany(p => p.AircTable)
                    .HasForeignKey(d => d.AirLoadTableId)
                    .HasConstraintName("FK_AIRCTABL_REFERENCE_AIRLOADT");

                entity.HasOne(d => d.AircTypeTable)
                    .WithMany(p => p.AircTable)
                    .HasForeignKey(d => d.AircTypeTableId)
                    .HasConstraintName("FK_AIRCTABL_REFERENCE_AIRCTYPE");

                entity.HasOne(d => d.UnitTable)
                    .WithMany(p => p.AircTable)
                    .HasForeignKey(d => d.UnitTableId)
                    .HasConstraintName("FK_AIRCTABL_REFERENCE_UNITTABL");
            });

            modelBuilder.Entity<AircTypeTable>(entity =>
            {
                entity.ToTable("aircTypeTable");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AirFacTableId).HasColumnName("airFacTable_id");

                entity.HasOne(d => d.AirFacTable)
                    .WithMany(p => p.AircTypeTable)
                    .HasForeignKey(d => d.AirFacTableId)
                    .HasConstraintName("FK_AIRCTYPE_REFERENCE_AIRFACTA");
            });

            modelBuilder.Entity<AirFacTable>(entity =>
            {
                entity.ToTable("airFacTable");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FacAddr)
                    .HasColumnName("fac_addr")
                    .HasMaxLength(100);

                entity.Property(e => e.FacName)
                    .HasColumnName("fac_name")
                    .HasMaxLength(50);

                entity.Property(e => e.LinkMan)
                    .HasColumnName("link_man")
                    .HasMaxLength(20);

                entity.Property(e => e.Telephone)
                    .HasColumnName("telephone")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<AirLoadTable>(entity =>
            {
                entity.ToTable("airLoadTable");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.EquipDesc).HasColumnName("equip_desc");

                entity.Property(e => e.EquipFacTableId).HasColumnName("equipFacTable_id");

                entity.Property(e => e.EquipName)
                    .HasColumnName("equip_name")
                    .HasMaxLength(20);

                entity.HasOne(d => d.EquipFacTable)
                    .WithMany(p => p.AirLoadTable)
                    .HasForeignKey(d => d.EquipFacTableId)
                    .HasConstraintName("FK_AIRLOADT_REFERENCE_EQUIPFAC");
            });

            modelBuilder.Entity<CameraFacTable>(entity =>
            {
                entity.ToTable("cameraFacTable");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CameraFacAddr)
                    .HasColumnName("camera_fac_addr")
                    .HasMaxLength(100);

                entity.Property(e => e.CameraFacName)
                    .HasColumnName("camera_fac_name")
                    .HasMaxLength(50);

                entity.Property(e => e.LinkMan)
                    .HasColumnName("link_man")
                    .HasMaxLength(20);

                entity.Property(e => e.Telephone)
                    .HasColumnName("telephone")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<CameraTable>(entity =>
            {
                entity.ToTable("cameraTable");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CameraAddr)
                    .HasColumnName("camera_addr")
                    .HasMaxLength(50);

                entity.Property(e => e.CameraName)
                    .HasColumnName("camera_name")
                    .HasMaxLength(20);

                entity.Property(e => e.CameraPort)
                    .HasColumnName("camera_port")
                    .HasMaxLength(5);

                entity.Property(e => e.CameraPwd)
                    .HasColumnName("camera_pwd")
                    .HasMaxLength(20);

                entity.Property(e => e.CameraTypeTableId).HasColumnName("cameraTypeTable_id");

                entity.Property(e => e.CameraX).HasColumnName("camera_x");

                entity.Property(e => e.CameraY).HasColumnName("camera_y");

                entity.Property(e => e.CameraZ).HasColumnName("camera_z");

                entity.Property(e => e.IpAddr)
                    .HasColumnName("ip_addr")
                    .HasMaxLength(20);

                entity.Property(e => e.UnitTableId).HasColumnName("unitTable_id");

                entity.HasOne(d => d.CameraTypeTable)
                    .WithMany(p => p.CameraTable)
                    .HasForeignKey(d => d.CameraTypeTableId)
                    .HasConstraintName("FK_CAMERATA_REFERENCE_CAMERATY");

                entity.HasOne(d => d.UnitTable)
                    .WithMany(p => p.CameraTable)
                    .HasForeignKey(d => d.UnitTableId)
                    .HasConstraintName("FK_CAMERATA_REFERENCE_UNITTABL");
            });

            modelBuilder.Entity<CameraTypeTable>(entity =>
            {
                entity.ToTable("cameraTypeTable");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CameraFacTableId).HasColumnName("cameraFacTable_id");

                entity.Property(e => e.CameraTypeName)
                    .HasColumnName("camera_type_name")
                    .HasMaxLength(20);

                entity.HasOne(d => d.CameraFacTable)
                    .WithMany(p => p.CameraTypeTable)
                    .HasForeignKey(d => d.CameraFacTableId)
                    .HasConstraintName("FK_CAMERATY_REFERENCE_CAMERAFA");
            });

            modelBuilder.Entity<DivisionTable>(entity =>
            {
                entity.ToTable("divisionTable");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(12)
                    .ValueGeneratedNever();

                entity.Property(e => e.DivisionName)
                    .HasColumnName("division_name")
                    .HasMaxLength(100);

                entity.Property(e => e.PId)
                    .HasColumnName("p_id")
                    .HasMaxLength(12);
            });

            modelBuilder.Entity<EquipFacTable>(entity =>
            {
                entity.ToTable("equipFacTable");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EquipFacAddr)
                    .HasColumnName("equip_fac_addr")
                    .HasMaxLength(100);

                entity.Property(e => e.EquipFacName)
                    .HasColumnName("equip_fac_name")
                    .HasMaxLength(50);

                entity.Property(e => e.LinkMan)
                    .HasColumnName("link_man")
                    .HasMaxLength(20);

                entity.Property(e => e.Telephone)
                    .HasColumnName("telephone")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<EventTypeTable>(entity =>
            {
                entity.ToTable("eventTypeTable");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.EventDesc)
                    .HasColumnName("event_desc")
                    .HasMaxLength(200);

                entity.Property(e => e.EventName)
                    .HasColumnName("event_name")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<EventVideoTable>(entity =>
            {
                entity.ToTable("eventVideoTable");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.EventTableId).HasColumnName("eventTable_id");

                entity.Property(e => e.VideoPath)
                    .HasColumnName("video_path")
                    .HasMaxLength(200);

                entity.HasOne(d => d.EventTable)
                    .WithMany(p => p.EventVideoTable)
                    .HasForeignKey(d => d.EventTableId)
                    .HasConstraintName("FK_EVENTVID_REFERENCE_EVEVTTAB");
            });

            modelBuilder.Entity<EvevtImgTable>(entity =>
            {
                entity.ToTable("evevtImgTable");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EventTableId).HasColumnName("eventTable_id");

                entity.Property(e => e.ImgPath)
                    .HasColumnName("img_path")
                    .HasMaxLength(200);

                entity.HasOne(d => d.EventTable)
                    .WithMany(p => p.EvevtImgTable)
                    .HasForeignKey(d => d.EventTableId)
                    .HasConstraintName("FK_EVEVTIMG_REFERENCE_EVEVTTAB");
            });

            modelBuilder.Entity<EvevtTable>(entity =>
            {
                entity.ToTable("evevtTable");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.EventDesc)
                    .HasColumnName("event_desc")
                    .HasMaxLength(200);

                entity.Property(e => e.EventTime)
                    .HasColumnName("event_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.EventTypeTableId).HasColumnName("eventTypeTable_id");

                entity.Property(e => e.ExecTaskTableId).HasColumnName("execTaskTable_id");

                entity.Property(e => e.PosX).HasColumnName("pos_x");

                entity.Property(e => e.PosY).HasColumnName("pos_y");

                entity.Property(e => e.PosZ).HasColumnName("pos_z");

                entity.HasOne(d => d.EventTypeTable)
                    .WithMany(p => p.EvevtTable)
                    .HasForeignKey(d => d.EventTypeTableId)
                    .HasConstraintName("FK_EVEVTTAB_REFERENCE_EVENTTYP");

                entity.HasOne(d => d.ExecTaskTable)
                    .WithMany(p => p.EvevtTable)
                    .HasForeignKey(d => d.ExecTaskTableId)
                    .HasConstraintName("FK_EVEVTTAB_REFERENCE_EXECTASK");
            });

            modelBuilder.Entity<ExecTaskTable>(entity =>
            {
                entity.ToTable("execTaskTable");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AircTableId).HasColumnName("aircTable_id");

                entity.Property(e => e.EndTime)
                    .HasColumnName("end_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.StartTime)
                    .HasColumnName("start_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.TaskStateTableId).HasColumnName("taskStateTable_id");

                entity.Property(e => e.TaskTableId).HasColumnName("taskTable_id");

                entity.Property(e => e.UserTableId).HasColumnName("userTable_id");

                entity.HasOne(d => d.TaskTable)
                    .WithMany(p => p.ExecTaskTable)
                    .HasForeignKey(d => d.TaskTableId)
                    .HasConstraintName("FK_EXECTASK_REFERENCE_TASKTABL");
            });

            modelBuilder.Entity<PermissonTable>(entity =>
            {
                entity.ToTable("permissonTable");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.PId).HasColumnName("p_id");

                entity.Property(e => e.PermissonDesc)
                    .HasColumnName("permisson_desc")
                    .HasMaxLength(100);

                entity.Property(e => e.PermissonName)
                    .HasColumnName("permisson_name")
                    .HasMaxLength(20);

                entity.Property(e => e.PermissonUrl)
                    .HasColumnName("permisson_url")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<RolePermissionTable>(entity =>
            {
                entity.ToTable("rolePermissionTable");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.PermissonTableId).HasColumnName("permissonTable_id");

                entity.Property(e => e.RoleTableId).HasColumnName("roleTable_id");

                entity.HasOne(d => d.PermissonTable)
                    .WithMany(p => p.RolePermissionTable)
                    .HasForeignKey(d => d.PermissonTableId)
                    .HasConstraintName("FK_ROLEPERM_REFERENCE_PERMISSO");

                entity.HasOne(d => d.RoleTable)
                    .WithMany(p => p.RolePermissionTable)
                    .HasForeignKey(d => d.RoleTableId)
                    .HasConstraintName("FK_ROLEPERM_REFERENCE_ROLETABL");
            });

            modelBuilder.Entity<RoleTable>(entity =>
            {
                entity.ToTable("roleTable");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.RoleDesc).HasColumnName("role_desc");

                entity.Property(e => e.RoleName)
                    .HasColumnName("role_name")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<StreamVideoServerTable>(entity =>
            {
                entity.ToTable("streamVideoServerTable");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.PlayName)
                    .HasColumnName("play_name")
                    .HasMaxLength(20);

                entity.Property(e => e.PlayPwd)
                    .HasColumnName("play_pwd")
                    .HasMaxLength(20);

                entity.Property(e => e.PushName)
                    .HasColumnName("push_name")
                    .HasMaxLength(20);

                entity.Property(e => e.PushPwd)
                    .HasColumnName("push_pwd")
                    .HasMaxLength(20);

                entity.Property(e => e.ServerAddr)
                    .HasColumnName("server_addr")
                    .HasMaxLength(50);

                entity.Property(e => e.ServerName)
                    .HasColumnName("server_name")
                    .HasMaxLength(20);

                entity.Property(e => e.ServerPort)
                    .HasColumnName("server_port")
                    .HasMaxLength(5);
            });

            modelBuilder.Entity<TaskStateTable>(entity =>
            {
                entity.ToTable("taskStateTable");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.StateName)
                    .HasColumnName("state_name")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<TaskTable>(entity =>
            {
                entity.ToTable("taskTable");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.EndTime)
                    .HasColumnName("end_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.PubTime)
                    .HasColumnName("pub_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.TaskDesc).HasColumnName("task_desc");

                entity.Property(e => e.TaskName)
                    .HasColumnName("task_name")
                    .HasMaxLength(50);

                entity.Property(e => e.TaskStateTableId).HasColumnName("taskStateTable_id");

                entity.Property(e => e.TaskTypeTableId).HasColumnName("taskTypeTable_id");

                entity.Property(e => e.UserTableId).HasColumnName("userTable_id");

                entity.HasOne(d => d.TaskStateTable)
                    .WithMany(p => p.TaskTable)
                    .HasForeignKey(d => d.TaskStateTableId)
                    .HasConstraintName("FK_TASKTABL_REFERENCE_TASKSTAT");

                entity.HasOne(d => d.TaskTypeTable)
                    .WithMany(p => p.TaskTable)
                    .HasForeignKey(d => d.TaskTypeTableId)
                    .HasConstraintName("FK_TASKTABL_REFERENCE_TASKTYPE");
            });

            modelBuilder.Entity<TaskTypeTable>(entity =>
            {
                entity.ToTable("taskTypeTable");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.TaskTypeName)
                    .HasColumnName("task_type_name")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<TaskUserTable>(entity =>
            {
                entity.ToTable("taskUserTable");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.FlyTaskTableId).HasColumnName("flyTaskTable_id");

                entity.Property(e => e.UserTableId).HasColumnName("userTable_id");

                entity.HasOne(d => d.FlyTaskTable)
                    .WithMany(p => p.TaskUserTable)
                    .HasForeignKey(d => d.FlyTaskTableId)
                    .HasConstraintName("FK_TASKUSER_REFERENCE_TASKTABL");

                entity.HasOne(d => d.UserTable)
                    .WithMany(p => p.TaskUserTable)
                    .HasForeignKey(d => d.UserTableId)
                    .HasConstraintName("FK_TASKUSER_REFERENCE_USERTABL");
            });

            modelBuilder.Entity<UnitTable>(entity =>
            {
                entity.ToTable("unitTable");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.DivisionTableId)
                    .HasColumnName("divisionTable_id")
                    .HasMaxLength(12);

                entity.Property(e => e.StreamVideoServerTableId).HasColumnName("streamVideoServerTable_id");

                entity.Property(e => e.UnitAddr)
                    .HasColumnName("unit_addr")
                    .HasMaxLength(100);

                entity.Property(e => e.UnitDesc).HasColumnName("unit_desc");

                entity.Property(e => e.UnitName)
                    .HasColumnName("unit_name")
                    .HasMaxLength(100);

                entity.Property(e => e.UnitPhone)
                    .HasColumnName("unit_phone")
                    .HasMaxLength(20);

                entity.HasOne(d => d.DivisionTable)
                    .WithMany(p => p.UnitTable)
                    .HasForeignKey(d => d.DivisionTableId)
                    .HasConstraintName("FK_UNITTABL_REFERENCE_DIVISION");

                entity.HasOne(d => d.StreamVideoServerTable)
                    .WithMany(p => p.UnitTable)
                    .HasForeignKey(d => d.StreamVideoServerTableId)
                    .HasConstraintName("FK_UNITTABL_REFERENCE_STREAMVI");
            });

            modelBuilder.Entity<UserRoleTable>(entity =>
            {
                entity.ToTable("userRoleTable");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.RoleTableId).HasColumnName("roleTable_id");

                entity.Property(e => e.UserTableId).HasColumnName("userTable_id");

                entity.HasOne(d => d.RoleTable)
                    .WithMany(p => p.UserRoleTable)
                    .HasForeignKey(d => d.RoleTableId)
                    .HasConstraintName("FK_USERROLE_REFERENCE_ROLETABL");

                entity.HasOne(d => d.UserTable)
                    .WithMany(p => p.UserRoleTable)
                    .HasForeignKey(d => d.UserTableId)
                    .HasConstraintName("FK_USERROLE_REFERENCE_USERTABL");
            });

            modelBuilder.Entity<UserTable>(entity =>
            {
                entity.ToTable("userTable");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(20);

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasMaxLength(4);

                entity.Property(e => e.LastLoginTime)
                    .HasColumnName("last_login_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.LoginCount).HasColumnName("login_count");

                entity.Property(e => e.LoginName)
                    .HasColumnName("login_name")
                    .HasMaxLength(20);

                entity.Property(e => e.LoginPwd)
                    .HasColumnName("login_pwd")
                    .HasMaxLength(20);

                entity.Property(e => e.RealName)
                    .HasColumnName("real_name")
                    .HasMaxLength(20);

                entity.Property(e => e.RegTime)
                    .HasColumnName("reg_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Telephone)
                    .HasColumnName("telephone")
                    .HasMaxLength(20);

                entity.Property(e => e.UnitTableId).HasColumnName("unitTable_id");

                entity.Property(e => e.ViewName)
                    .HasColumnName("view_name")
                    .HasMaxLength(20);

                entity.HasOne(d => d.UnitTable)
                    .WithMany(p => p.UserTable)
                    .HasForeignKey(d => d.UnitTableId)
                    .HasConstraintName("FK_USERTABL_REFERENCE_UNITTABL");
            });
        }
    }
}
