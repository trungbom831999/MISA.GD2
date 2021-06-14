<template>
  <div id="menu">
    <div id="menu-logo">
      <a href="#" class="menu-btn-option"></a>
      <a href="#" class="logo">
        <img
          src="../../assets/img/Logo_Module_TiengViet_White.66947422.svg"
          alt="Logo kế toán"
          class="logo-img"
        />
      </a>
    </div>
    <div id="menu-list" class="scroller">
      <router-link to="/index" class="menu-item" title="Trang chủ">
        <div class="menu-item__icon">
          <div class="mi mi-24 mi-sidebar-cash"></div>
        </div>
        <div class="menu-item__title">Tiền mặt</div>
      </router-link>
      <!-- <router-link to="/supplier" class="menu-item" title="Nhà cung cấp">
        <div class="menu-item__icon">
          <div class="mi mi-24 mi-sidebar-dashboard"></div>
        </div>
        <div class="menu-item__title">Nhà cung cấp</div>
      </router-link>
      <router-link to="/account" class="menu-item" title="Danh sách tài khoản">
        <div class="menu-item__icon">
          <div class="mi mi-24 mi-sidebar-cash"></div>
        </div>
        <div class="menu-item__title">Danh sách tài khoản</div>
      </router-link>
      <router-link to="/cash" class="menu-item" title="Phiếu chi">
        <div class="menu-item__icon">
          <div class="mi mi-24 mi-sidebar-bank"></div>
        </div>
        <div class="menu-item__title">Phiếu chi</div>
      </router-link> -->
    </div>
  </div>
</template>

<style>
#menu {
  width: auto;
  /* width: 178px; */
  font-size: 13px;
  position: relative;
  background-color: #393a3d;
}

#menu-logo {
  display: flex;
  background-color: #38393d;
  padding: 10px;
  height: 48px;
  align-items: center;
  justify-content: center;
}
/*nút ẩn hiện menu*/
.menu-btn-option {
  width: 24px;
  height: 24px;
  margin-right: 10px;
  background: url(../../assets/img/Sprites.64af8f61.svg) no-repeat -424px -86px;
}

/*logo kế toán*/
.logo {
  height: 32px;
  display: block;
}

.logo-img {
  height: 32px;
}

/*danh sách các danh mục menu*/
#menu-list {
  height: calc(100vh - 48px);
  padding-top: 14px;
  padding-right: 8px;
}

/*1 danh mục trong menu */
.menu-item {
  line-height: 42px;
  height: 42px;
  border-left: 6px solid transparent;
  padding-left: 8px;
  color: #fff;
  position: relative;
  display: flex;
  cursor: pointer;
}

.menu-item .menu-item__icon {
  display: flex;
  align-items: center;
  margin-right: 8px;
}

.menu-item:hover:before {
  content: "";
  background: #fff;
  opacity: 0.2;
  width: calc(100% + 6px);
  height: 42px;
  left: -6px;
  top: 0;
  position: absolute;
}
</style>
<style scoped>
a{
  color: #fff !important;
}
</style>

<script>
export default {
  mounted() {},
  methods: {},
};
</script>
