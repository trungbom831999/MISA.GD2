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
      <router-link to="/supplier" class="menu-item" title="Nhà cung cấp">
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
      <router-link to="/payment" class="menu-item" title="Phiếu chi">
        <div class="menu-item__icon">
          <div class="mi mi-24 mi-sidebar-bank"></div>
        </div>
        <div class="menu-item__title">Phiếu chi</div>
      </router-link>

      <a href="#" class="menu-item" title="Tổng quan"
        ><div class="menu-item__icon">
          <div class="mi mi-24 mi-sidebar-dashboard"></div>
        </div>
        <div class="menu-item__title">Tổng quan</div>
      </a>

      <a href="#" class="menu-item" title="Tiền mặt"
        ><div class="menu-item__icon">
          <div class="mi mi-24 mi-sidebar-cash"></div>
        </div>
        <div class="menu-item__title">Tiền mặt</div>
      </a>

      <a href="#" class="menu-item" title="Tiền gửi"
        ><div class="menu-item__icon">
          <div class="mi mi-24 mi-sidebar-bank"></div>
        </div>
        <div class="menu-item__title">Tiền gửi</div>
      </a>

      <a href="#" class="menu-item" title="Mua hàng"
        ><div class="menu-item__icon">
          <div class="mi mi-24 mi-sidebar-pu"></div>
        </div>
        <div class="menu-item__title">Mua hàng</div>
      </a>

      <a href="#" class="menu-item" title="Bán hàng"
        ><div class="menu-item__icon">
          <div class="mi mi-24 mi-sidebar-sale"></div>
        </div>
        <div class="menu-item__title">Bán hàng</div>
      </a>

      <a href="#" class="menu-item" title="Quản lý hóa đơn"
        ><div class="menu-item__icon">
          <div class="mi mi-24 mi-sidebar-invoice"></div>
        </div>
        <div class="menu-item__title">Quản lý hóa đơn</div>
      </a>

      <a href="#" class="menu-item" title="Kho"
        ><div class="menu-item__icon">
          <div class="mi mi-24 mi-sidebar-stock"></div>
        </div>
        <div class="menu-item__title">Kho</div>
      </a>

      <a href="#" class="menu-item" title="Công cụ dụng cụ"
        ><div class="menu-item__icon">
          <div class="mi mi-24 mi-sidebar-tools"></div>
        </div>
        <div class="menu-item__title">Công cụ dụng cụ</div>
      </a>

      <a href="#" class="menu-item" title="Tài sản cố định"
        ><div class="menu-item__icon">
          <div class="mi mi-24 mi-sidebar-fixed-assets"></div>
        </div>
        <div class="menu-item__title">Tài sản cố định</div>
      </a>

      <a href="#" class="menu-item" title="Thuế"
        ><div class="menu-item__icon">
          <div class="mi mi-24 mi-sidebar-tax"></div>
        </div>
        <div class="menu-item__title">Thuế</div>
      </a>

      <a href="#" class="menu-item" title="Giá thành"
        ><div class="menu-item__icon">
          <div class="mi mi-24 mi-sidebar-price"></div>
        </div>
        <div class="menu-item__title">Giá thành</div>
      </a>

      <a href="#" class="menu-item" title="Tổng hợp"
        ><div class="menu-item__icon">
          <div class="mi mi-24 mi-sidebar-general"></div>
        </div>
        <div class="menu-item__title">Tổng hợp</div>
      </a>

      <a href="#" class="menu-item" title="Ngân sách"
        ><div class="menu-item__icon">
          <div class="mi mi-24 mi-sidebar-budget"></div>
        </div>
        <div class="menu-item__title">Ngân sách</div>
      </a>

      <a href="#" class="menu-item" title="Báo cáo"
        ><div class="menu-item__icon">
          <div class="mi mi-24 mi-sidebar-report"></div>
        </div>
        <div class="menu-item__title">Báo cáo</div>
      </a>

      <a href="#" class="menu-item" title="Phân tích tài chính"
        ><div class="menu-item__icon">
          <div class="mi mi-24 mi-sidebar-finance"></div>
        </div>
        <div class="menu-item__title">Phân tích tài chính</div>
      </a>
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
