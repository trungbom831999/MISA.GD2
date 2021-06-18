<template>
  <div class="ms-popup popup-payment">
    <div
      class="ms-component con-ms-popup"
      :style="[!isShowPopup ? { display: 'none' } : { display: 'block' }]"
      @keyup.esc="$emit('closePaymentPopup', false)"
      tabindex="0"
    >
      <div
        class="ms-popup ms-popup-content"
        style="min-width: 100vw; max-width: 100vw; width: 100vw; height: 100vh"
      >
        <div class="ms-popup--content px-0">
          <div class="header-layout-wrap">
            <div class="flex">
              <div class="base-view-detail">
                <!-- header -->
                <div class="header">
                  <div class="top-header">
                    <div class="flex align-center">
                      <div class="recent-log-btn">
                        <div class="mi mi-24 mi-recent-log"></div>
                      </div>
                    </div>

                    <div class="title">
                      Phiếu chi {{ payment.paymentnumber }}
                    </div>
                    <div class="header-detail-input">
                      <div class="combo-header combo-editor width-350">
                        <ms-select
                          ref="selectTypePayment"
                          :items="typeOfPayment"
                          :itemDefault="4"
                          autofocus
                          :readonly="isReadOnly ? true : false"
                        ></ms-select>
                      </div>

                      <!-- <div class="combo-header">
                        <label class="inline-label"
                          >Phương thức thanh toán</label
                        >
                        <ms-select
                          class="width-170"
                          :items="paymentMethods"
                          :itemDefault="0"
                        ></ms-select>
                      </div> -->
                    </div>

                    <div class="header-detail-buttons flex">
                      <div class="guide-tour">
                        <div class="mi mi-24 mi-tour"></div>
                        <div class="tour-label">Hướng dẫn</div>
                      </div>

                      <div class="con-ms-btn-header">
                        <div class="header-detail-btn">
                          <div class="mi mi-24 mi-setting__detail"></div>
                        </div>
                      </div>
                      <div class="con-ms-btn-header">
                        <div class="header-detail-btn">
                          <div class="mi mi-24 mi-help"></div>
                        </div>
                      </div>
                      <div class="con-ms-btn-header">
                        <div class="header-detail-btn">
                          <div
                            class="mi mi-24 mi-close"
                            title="Đóng (ESC)"
                            @click="closePopup()"
                          ></div>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>

                <!-- body  -->
                <div class="body">
                  <div class="w-full bgr-main-information sticky left-0">
                    <div class="main-information">
                      <div class="flex inner-basic-information">
                        <div class="w-3/4">
                          <div class="m-row basic-information flex">
                            <div class="w-4/5">
                              <!-- <div class="m-row flex row-input">
                                <div class="w-3/7">
                                  <select-auto-complete-menu-table
                                    label="Tài khoản chi"
                                    :column="colAccountPay"
                                    :items="accountPays"
                                    mainItem="accountNumber"
                                    :hasAddButton="true"
                                  ></select-auto-complete-menu-table>
                                </div>
                                <div class="w-4/7 flex-grow pxs-4">
                                  <ms-input></ms-input>
                                </div>
                              </div> -->

                              <div class="m-row flex row-input">
                                <div class="w-3/7">
                                  <select-auto-complete-menu-table
                                    label="Đối tượng"
                                    :column="colTheObject"
                                    :items="theObjects"
                                    valueItem="objectCode"
                                    mainItem="objectName"
                                    :hasAddButton="true"
                                    v-model="payment.paymentobjectcode"
                                    :readonly="isReadOnly ? true : false"
                                    @input="(startWatch=true)"
                                  ></select-auto-complete-menu-table>
                                </div>
                                <div class="w-4/7 flex-grow pxs-4">
                                  <ms-input
                                    label="Người nhận"
                                    v-model="payment.paymentobjectname"
                                    :readonly="isReadOnly ? true : false"
                                  ></ms-input>
                                </div>
                              </div>

                              <!-- <div class="m-row flex row-input">
                                <div class="w-3/7">
                                  <select-auto-complete-menu-table
                                    label="Tài khoản nhận"
                                    :column="colAccountReceive"
                                    :items="accountReceives"
                                    mainItem="accountNumber"
                                  ></select-auto-complete-menu-table>
                                </div>
                                <div class="w-4/7 flex-grow pxs-4">
                                  <ms-input></ms-input>
                                </div>
                              </div> -->

                              <div class="m-row flex row-input">
                                <div class="w-full p-r-16">
                                  <ms-input
                                    label="Địa chỉ"
                                    v-model="payment.paymentaddress"
                                    :readonly="isReadOnly ? true : false"
                                  ></ms-input>
                                </div>
                              </div>

                              <div class="m-row flex row-input">
                                <div class="w-full p-r-16">
                                  <ms-input
                                    label="Lý do chi"
                                    v-model="payment.reasonpay"
                                    :readonly="isReadOnly ? true : false"
                                    @input="(startWatch=true)"
                                  ></ms-input>
                                </div>
                              </div>

                              <div
                                class="m-row flex row-input n-padding-bottom"
                              >
                                <div class="w-3/7 p-r-14">
                                  <select-auto-complete-menu-table
                                    label="Nhân viên"
                                    :column="colEmployee"
                                    :items="employees"
                                    mainItem="employeeName"
                                    valueItem="employeeCode"
                                    :hasAddButton="true"
                                    v-model="payment.paymentemployeecode"
                                    :readonly="isReadOnly ? true : false"
                                  ></select-auto-complete-menu-table>
                                </div>
                                <!-- <div class="w-4/7 p-l-12 p-r-16">
                                  <div class="m-row reference flex">
                                    <div class="ms-reference">
                                      <div class="reference-title">
                                        Tham chiếu
                                      </div>
                                      <div class="ms-reference-show-more">
                                        ...
                                      </div>
                                    </div>
                                  </div>
                                </div> -->
                                <div class="w-4/7 flex width-240">
                                  <ms-input
                                    label="Kèm theo"
                                    placeholder="Số lượng"
                                    textRight
                                    numberInput
                                    v-model="payment.numberoflicense"
                                    :readonly="isReadOnly ? true : false"
                                  ></ms-input>
                                  <div class="root-invoice px-2">
                                    chứng từ gốc
                                  </div>
                                </div>
                              </div>

                              <div class="m-row reference flex">
                                <div class="ms-reference">
                                  <div class="reference-title">Tham chiếu</div>
                                  <div class="ms-reference-show-more">...</div>
                                </div>
                              </div>
                            </div>

                            <div class="w-1/5">
                              <div class="row-input-right">
                                <ms-input-date
                                  label="Ngày hạch toán"
                                  placeholder="dd/mm/yyyy"
                                  ref="inputAccountingDate"
                                  v-model="payment.accountingdate"
                                  :isError="
                                    (validateAccountingDate() ? false : true) &&
                                    mustValidate
                                  "
                                  :readonly="isReadOnly ? true : false"
                                ></ms-input-date>
                              </div>

                              <div class="row-input-right">
                                <ms-input-date
                                  label="Ngày phiếu chi"
                                  placeholder="dd/mm/yyyy"
                                  v-model="payment.paymentdate"
                                  :readonly="isReadOnly ? true : false"
                                ></ms-input-date>
                              </div>

                              <div class="row-input-right">
                                <ms-input
                                  label="Số phiếu chi"
                                  ref="inputPaymentNumber"
                                  v-model="payment.paymentnumber"
                                  :error="
                                    (payment.paymentnumber ? false : true) &&
                                    mustValidate
                                  "
                                  :readonly="isReadOnly ? true : false"
                                ></ms-input>
                              </div>
                            </div>
                          </div>
                        </div>

                        <div class="w-1/4 summary-info">
                          <div class="summary-info-title">Tổng tiền</div>
                          <h1 class="summary-info-number">
                            {{ payment.totalmoney * exchangeRate }}
                          </h1>
                        </div>
                      </div>
                    </div>
                  </div>

                  <!-- bảng hạch toán   -->
                  <div class="grid-tab">
                    <div
                      class="
                        ms-tabs
                        con-ms-tabs
                        tab-grid
                        ms-tabs-position-top
                        grid-tab-single
                      "
                    >
                      <div class="con-ms-ul-tabs tab-detail">
                        <ul class="ul-tabs ms-tabs-ul ms-ul-tabs-left">
                          <li class="ms-tabs-li flex active-item">
                            <div class="ms-tabs-btn tab-detail-none-underLine">
                              <div class="ms-label tab-label">Hạch toán</div>
                            </div>
                          </li>
                        </ul>

                        <div class="tab-header-extend-con">
                          <div class="grid-option flex">
                            <div class="label-option">Loại tiền</div>
                            <div class="combo-editor currency-combobox">
                              <select-auto-complete-menu-table
                                v-model="payment.typeofmoney"
                                :column="colTypeOfMoney"
                                :items="typeOfMoneys"
                                itemDefault="0"
                                mainItem="moneyCode"
                                @input="getExchangeRate()"
                                :readonly="isReadOnly ? true : false"
                              ></select-auto-complete-menu-table>
                            </div>

                            <div
                              v-if="payment.typeofmoney != 'VND'"
                              class="label-option"
                            >
                              Tỷ giá
                            </div>
                            <div
                              v-if="payment.typeofmoney != 'VND'"
                              class="cls-width-exchange-rate"
                            >
                              <ms-input
                                textRight
                                v-model="exchangeRate"
                                :readonly="isReadOnly ? true : false"
                                numberInput
                              ></ms-input>
                            </div>
                          </div>
                        </div>
                      </div>

                      <div class="con-slot-tabs">
                        <div class="ms-tabs--content ms-tab-shared--content">
                          <div class="grid-detail-data">
                            <div class="grid-model-control">
                              <div class="gridComponent">
                                <div class="ms-component ms-grid-editable-con">
                                  <div class="con-tablex">
                                    <div class="border-color">
                                      <div class="flex">
                                        <div
                                          class="table-scroll dynamic-table"
                                          style="
                                            min-height: 0px;
                                            max-height: none;
                                            overflow: unset;
                                          "
                                        >
                                          <table
                                            class="ms-table"
                                            style="min-width: calc(100% + 0px)"
                                          >
                                            <thead class="ms-table--thead">
                                              <tr>
                                                <th
                                                  style="
                                                    min-width: 30px;
                                                    max-width: 30px;
                                                    width: 30px;
                                                    background: #fff;
                                                    position: sticky;
                                                    left: 0px;
                                                    border: 0px;
                                                    z-index: 40;
                                                    top: 0px;
                                                  "
                                                ></th>
                                                <th
                                                  class="
                                                    check-multiple-columns
                                                    text-center
                                                    left-30
                                                  "
                                                  style="top: 0px"
                                                >
                                                  #
                                                </th>
                                                <th
                                                  class="dynamic-header p-0"
                                                  style="
                                                    min-width: 186px;
                                                    width: 186px;
                                                    top: 0px;
                                                  "
                                                >
                                                  <div
                                                    class="
                                                      flex
                                                      th-height
                                                      text-left
                                                    "
                                                  >
                                                    <div
                                                      class="
                                                        th-table
                                                        padding-th
                                                        w-full
                                                        cursor-pointer
                                                      "
                                                      style="
                                                        justify-content: left;
                                                      "
                                                    >
                                                      <span>Diễn giải</span>
                                                    </div>
                                                  </div>
                                                </th>

                                                <th
                                                  class="dynamic-header p-0"
                                                  style="
                                                    min-width: 100px;
                                                    width: 100px;
                                                    top: 0px;
                                                  "
                                                >
                                                  <div
                                                    class="
                                                      flex
                                                      th-height
                                                      text-left
                                                    "
                                                  >
                                                    <div
                                                      class="
                                                        th-table
                                                        padding-th
                                                        w-full
                                                        cursor-pointer
                                                      "
                                                      style="
                                                        justify-content: left;
                                                      "
                                                    >
                                                      <span>TK nợ</span>
                                                    </div>
                                                  </div>
                                                </th>

                                                <th
                                                  class="dynamic-header p-0"
                                                  style="
                                                    min-width: 100px;
                                                    width: 100px;
                                                    top: 0px;
                                                  "
                                                >
                                                  <div
                                                    class="
                                                      flex
                                                      th-height
                                                      text-left
                                                    "
                                                  >
                                                    <div
                                                      class="
                                                        th-table
                                                        padding-th
                                                        w-full
                                                        cursor-pointer
                                                      "
                                                      style="
                                                        justify-content: left;
                                                      "
                                                    >
                                                      <span>TK có</span>
                                                    </div>
                                                  </div>
                                                </th>

                                                <th
                                                  class="dynamic-header p-0"
                                                  style="
                                                    min-width: 150px;
                                                    width: 150px;
                                                    top: 0px;
                                                  "
                                                >
                                                  <div
                                                    class="
                                                      flex
                                                      th-height
                                                      text-right
                                                    "
                                                  >
                                                    <div
                                                      class="
                                                        th-table
                                                        padding-th
                                                        w-full
                                                        cursor-pointer
                                                      "
                                                      style="
                                                        justify-content: flex-end;
                                                      "
                                                    >
                                                      <span>Số tiền</span>
                                                    </div>
                                                  </div>
                                                </th>

                                                <th
                                                  v-if="
                                                    payment.typeofmoney != 'VND'
                                                  "
                                                  class="dynamic-header p-0"
                                                  style="
                                                    min-width: 150px;
                                                    width: 150px;
                                                    top: 0px;
                                                  "
                                                >
                                                  <div
                                                    class="
                                                      flex
                                                      th-height
                                                      text-right
                                                    "
                                                  >
                                                    <div
                                                      class="
                                                        th-table
                                                        padding-th
                                                        w-full
                                                        cursor-pointer
                                                      "
                                                      style="
                                                        justify-content: flex-end;
                                                      "
                                                    >
                                                      <span>Quy đổi</span>
                                                    </div>
                                                  </div>
                                                </th>

                                                <th
                                                  class="dynamic-header p-0"
                                                  style="
                                                    min-width: 150px;
                                                    width: 150px;
                                                    top: 0px;
                                                  "
                                                >
                                                  <div
                                                    class="
                                                      flex
                                                      th-height
                                                      text-left
                                                    "
                                                  >
                                                    <div
                                                      class="
                                                        th-table
                                                        padding-th
                                                        w-full
                                                        cursor-pointer
                                                      "
                                                      style="
                                                        justify-content: left;
                                                      "
                                                    >
                                                      <span>Đối tượng</span>
                                                    </div>
                                                  </div>
                                                </th>

                                                <th
                                                  class="dynamic-header p-0"
                                                  style="
                                                    min-width: 250px;
                                                    width: 250px;
                                                    top: 0px;
                                                  "
                                                >
                                                  <div
                                                    class="
                                                      flex
                                                      th-height
                                                      text-left
                                                    "
                                                  >
                                                    <div
                                                      class="
                                                        th-table
                                                        padding-th
                                                        w-full
                                                        cursor-pointer
                                                      "
                                                      style="
                                                        justify-content: left;
                                                      "
                                                    >
                                                      <span>Tên đối tượng</span>
                                                    </div>
                                                  </div>
                                                </th>

                                                <th
                                                  rowspan="2"
                                                  class="
                                                    text-right
                                                    wiget wiget-title
                                                    right-30
                                                  "
                                                  style="
                                                    min-width: 40px;
                                                    width: 40px;
                                                    max-width: 40px;
                                                    top: 0px;
                                                  "
                                                ></th>
                                                <th
                                                  class="outRight"
                                                  style="
                                                    min-width: 30px;
                                                    max-width: 30px;
                                                    width: 30px;
                                                    background: #fff;
                                                    position: sticky;
                                                    right: 0px;
                                                    border: 0px;
                                                    z-index: 40;
                                                    top: 0px;
                                                  "
                                                ></th>
                                              </tr>
                                            </thead>

                                            <tbody class="dis-contents">
                                              <tr
                                                v-for="(
                                                  account, index
                                                ) in accounting"
                                                :key="index"
                                                class="
                                                  tr-values
                                                  vs-table--tr
                                                  tr-table-state-null
                                                  selected
                                                "
                                              >
                                                <td
                                                  style="
                                                    min-width: 30px;
                                                    max-width: 30px;
                                                    width: 30px;
                                                    background: #fff;
                                                    position: sticky;
                                                    left: 0px;
                                                    border: 0px;
                                                    z-index: 40;
                                                  "
                                                ></td>
                                                <td
                                                  class="
                                                    td
                                                    ms-table--td
                                                    text-center
                                                    ms-grid-row-number
                                                  "
                                                >
                                                  <div class="stt-cell">
                                                    {{ index + 1 }}
                                                  </div>
                                                </td>

                                                <td
                                                  class="
                                                    td
                                                    ms-table--td
                                                    dynamic-column
                                                  "
                                                >
                                                  <div class="editable">
                                                    <div style="width: 100%">
                                                      <ms-textarea
                                                        gridEditor
                                                        rows="1"
                                                        maxlength="255"
                                                        v-model="
                                                          account.description
                                                        "
                                                        :readonly="
                                                          isReadOnly
                                                            ? true
                                                            : false
                                                        "
                                                      ></ms-textarea>
                                                    </div>
                                                  </div>
                                                </td>

                                                <td
                                                  class="
                                                    td
                                                    ms-table--td
                                                    dynamic-column
                                                  "
                                                >
                                                  <div class="editable">
                                                    <select-auto-complete-menu-table
                                                      :column="colAccountDebt"
                                                      :items="accountDebt"
                                                      mainItem="accountNumber"
                                                      v-model="
                                                        account.accountdebtnumber
                                                      "
                                                      :readonly="
                                                        isReadOnly
                                                          ? true
                                                          : false
                                                      "
                                                    ></select-auto-complete-menu-table>
                                                  </div>
                                                </td>

                                                <td
                                                  class="
                                                    td
                                                    ms-table--td
                                                    dynamic-column
                                                  "
                                                >
                                                  <div class="editable">
                                                    <select-auto-complete-menu-table
                                                      :column="colAccountDebt"
                                                      :items="accountDebt"
                                                      mainItem="accountNumber"
                                                      v-model="
                                                        account.accountreceivenumber
                                                      "
                                                      :readonly="
                                                        isReadOnly
                                                          ? true
                                                          : false
                                                      "
                                                    ></select-auto-complete-menu-table>
                                                  </div>
                                                </td>

                                                <!-- số tiền  -->
                                                <td
                                                  class="
                                                    td
                                                    ms-table--td
                                                    dynamic-column
                                                  "
                                                >
                                                  <div class="editable">
                                                    <ms-input
                                                      v-model="account.money"
                                                      textRight
                                                      numberInput
                                                      @input="sumMoney()"
                                                      :readonly="
                                                        isReadOnly
                                                          ? true
                                                          : false
                                                      "
                                                    ></ms-input>
                                                  </div>
                                                </td>

                                                <td
                                                  v-if="
                                                    payment.typeofmoney != 'VND'
                                                  "
                                                  class="
                                                    td
                                                    ms-table--td
                                                    dynamic-column
                                                  "
                                                >
                                                  <div class="editable">
                                                    <ms-input
                                                      textRight
                                                      numberInput
                                                      :value="
                                                        account.money *
                                                        exchangeRate
                                                      "
                                                      :readonly="
                                                        isReadOnly
                                                          ? true
                                                          : false
                                                      "
                                                    ></ms-input>
                                                  </div>
                                                </td>

                                                <td
                                                  class="
                                                    td
                                                    ms-table--td
                                                    dynamic-column
                                                  "
                                                >
                                                  <div class="editable">
                                                    <select-auto-complete-menu-table
                                                      :column="colTheObject"
                                                      :items="theObjects"
                                                      mainItem="objectCode"
                                                      v-model="
                                                        account.objectcode
                                                      "
                                                      :readonly="
                                                        isReadOnly
                                                          ? true
                                                          : false
                                                      "
                                                      @input="
                                                        fillObjectName(
                                                          account.objectcode,
                                                          index
                                                        )
                                                      "
                                                    ></select-auto-complete-menu-table>
                                                  </div>
                                                </td>

                                                <td
                                                  class="
                                                    td
                                                    ms-table--td
                                                    dynamic-column
                                                  "
                                                >
                                                  <div class="editable">
                                                    <ms-input
                                                      v-model="
                                                        account.objectname
                                                      "
                                                      readonly
                                                    ></ms-input>
                                                  </div>
                                                </td>

                                                <td
                                                  class="
                                                    td
                                                    ms-table--td
                                                    wiget
                                                    right-30
                                                  "
                                                >
                                                  <div
                                                    v-if="!isReadOnly"
                                                    class="
                                                      delete-function
                                                      flex
                                                      justify-center
                                                      align-center
                                                    "
                                                    @click="
                                                      deleteRowAccounting(index)
                                                    "
                                                  >
                                                    <div
                                                      class="mi mi-16 mi-delete"
                                                    ></div>
                                                  </div>
                                                </td>

                                                <td
                                                  style="
                                                    min-width: 30px;
                                                    max-width: 30px;
                                                    width: 30px;
                                                    background: #fff;
                                                    position: sticky;
                                                    right: 0px;
                                                    border: 0px;
                                                    z-index: 40;
                                                  "
                                                ></td>
                                              </tr>
                                            </tbody>
                                            <tfoot>
                                              <tr>
                                                <th
                                                  class="outLeft"
                                                  style="
                                                    min-width: 30px;
                                                    max-width: 30px;
                                                    width: 30px;
                                                    background: #fff;
                                                    position: sticky;
                                                    left: 0px;
                                                    border: 0px;
                                                    z-index: 40;
                                                  "
                                                ></th>
                                                <th
                                                  class="ms-grid-row-number"
                                                ></th>
                                                <th
                                                  class="dynamic-column"
                                                  style="text-align: left"
                                                >
                                                  <span></span>
                                                </th>
                                                <th
                                                  class="dynamic-column"
                                                  style="text-align: left"
                                                >
                                                  <span></span>
                                                </th>
                                                <th
                                                  class="dynamic-column"
                                                  style="text-align: left"
                                                >
                                                  <span></span>
                                                </th>
                                                <th
                                                  class="dynamic-column"
                                                  style="text-align: right"
                                                >
                                                  <span>{{
                                                    payment.totalmoney
                                                  }}</span>
                                                </th>
                                                <th
                                                  v-if="
                                                    payment.typeofmoney != 'VND'
                                                  "
                                                  class="dynamic-column"
                                                  style="text-align: right"
                                                >
                                                  <span
                                                    >{{
                                                      payment.totalmoney *
                                                      exchangeRate
                                                    }}
                                                  </span>
                                                </th>
                                                <th
                                                  class="dynamic-column"
                                                  style="text-align: left"
                                                >
                                                  <span></span>
                                                </th>
                                                <th
                                                  class="dynamic-column"
                                                  style="text-align: left"
                                                >
                                                  <span></span>
                                                </th>
                                                <th class="wiget right-30"></th>
                                                <th
                                                  style="
                                                    min-width: 30px;
                                                    max-width: 30px;
                                                    width: 30px;
                                                    background: #fff;
                                                    position: sticky;
                                                    right: 0px;
                                                    border: 0px;
                                                    z-index: 40;
                                                  "
                                                ></th>
                                              </tr>
                                            </tfoot>
                                          </table>
                                        </div>
                                      </div>
                                    </div>
                                  </div>
                                </div>
                              </div>
                            </div>
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>

                  <div class="grid-control-item flex sticky left-0">
                    <div class="w-3/4">
                      <div v-if="!isReadOnly" class="btn-grid-control">
                        <button
                          class="
                            ms-component
                            ms-button
                            ms-button-size-small
                            ms-button-secondary
                            ms-button-secondary-disabled-false
                            ms-button-radius-false
                            ms-button
                          "
                          @click="addRowAccounting()"
                        >
                          <div
                            class="
                              ms-button-text
                              ms-button--text
                              flex
                              align-center
                            "
                          >
                            <div>Thêm dòng</div>
                          </div>
                        </button>

                        <button
                          class="
                            ms-component
                            ms-button
                            ms-button-size-small
                            ms-button-secondary
                            ms-button-secondary-disabled-false
                            ms-button-radius-false
                            ms-button
                          "
                          @click="removeAllRowAccounting()"
                        >
                          <div
                            class="
                              ms-button-text
                              ms-button--text
                              flex
                              align-center
                            "
                          >
                            <div>Xóa hết dòng</div>
                          </div>
                        </button>
                      </div>

                      <div class="w-2/4 input-grid-control">
                        <div>
                          <div class="ms-upload mw-340">
                            <div class="ms-title-upload">
                              <div class="attach-text">
                                <div
                                  class="
                                    mi mi-18 mi-attach
                                    m-r-8
                                    cursor-default
                                  "
                                ></div>
                                <div>Đính kèm</div>
                              </div>
                              <div class="max-size-upload">
                                Dung lượng tối đa 5MB
                              </div>
                            </div>

                            <span>
                              <div class="ms-img-upload">
                                <div class="ms-input-upload">
                                  <input
                                    type="file"
                                    title=""
                                    accept=""
                                    multiple="multiple"
                                  />
                                  <span class="text-input"
                                    >Kéo/thả tệp vào đây hoặc bấm vào đây</span
                                  >
                                </div>
                              </div>
                            </span>
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>
                  <div class="clear"></div>
                </div>

                <!-- footer dialog  -->
                <div v-if="!isReadOnly" class="footer-container">
                  <div class="footer">
                    <div class="ms-footer-component" style="width: 100%">
                      <div class="m-row footer-button-group flex-row-reverse">
                        <div class="right-group-button flex">
                          <div class="flex flex-row-reverse">
                            <div class="footer-main-button">
                              <div class="ms-dropdown">
                                <button
                                  v-if="isSaveAndClose"
                                  name="button"
                                  class="
                                    ms-component
                                    ms-button
                                    ms-button-size-footer
                                    ms-button-primary
                                    ms-button-primary-disabled-false
                                    ms-button-radius-false
                                    ms-button
                                    ms-radius-false
                                    ms-dropdown-style-footer
                                    ms-radius-false
                                    ms-dropdown-type-primary
                                    ms-dropdown-padding-custom-primary
                                  "
                                  @click="savePayment()"
                                >
                                  <div
                                    class="
                                      ms-button-text
                                      ms-button--text
                                      flex
                                      align-center
                                    "
                                  >
                                    Cất và Đóng
                                  </div>
                                </button>
                                <button
                                  v-if="isSaveAndAddNew"
                                  name="button"
                                  class="
                                    ms-component
                                    ms-button
                                    ms-button-size-footer
                                    ms-button-primary
                                    ms-button-primary-disabled-false
                                    ms-button-radius-false
                                    ms-button
                                    ms-radius-false
                                    ms-dropdown-style-footer
                                    ms-radius-false
                                    ms-dropdown-type-primary
                                    ms-dropdown-padding-custom-primary
                                  "
                                >
                                  <div
                                    class="
                                      ms-button-text
                                      ms-button--text
                                      flex
                                      align-center
                                    "
                                  >
                                    Cất và Thêm
                                  </div>
                                </button>
                                <button
                                  v-if="isSaveAndPrint"
                                  name="button"
                                  class="
                                    ms-component
                                    ms-button
                                    ms-button-size-footer
                                    ms-button-primary
                                    ms-button-primary-disabled-false
                                    ms-button-radius-false
                                    ms-button
                                    ms-radius-false
                                    ms-dropdown-style-footer
                                    ms-radius-false
                                    ms-dropdown-type-primary
                                    ms-dropdown-padding-custom-primary
                                  "
                                >
                                  <div
                                    class="
                                      ms-button-text
                                      ms-button--text
                                      flex
                                      align-center
                                    "
                                  >
                                    Cất và In
                                  </div>
                                </button>
                                <dropdown-button top>
                                  <template slot="dropdown-button">
                                    <button
                                      name="button"
                                      class="
                                        ms-component ms-button ms-con-dropdown
                                        parent-dropdown
                                        expand-more-button
                                        ms-button-size-footer
                                        ms-button-primary
                                        ms-button-primary-disabled-false
                                        ms-button-radius-false
                                        ms-button
                                        ms-dropdown-type-primary
                                        ms-con-dropdown-radius-false-false
                                        ms-con-dropdown-radius-false-primary
                                        ms-padding-is-single-false-size-footer
                                        ms-dropdown-style
                                        ms-con-dropdown
                                        parent-dropdown
                                        expand-more-button
                                      "
                                    >
                                      <div
                                        class="
                                          ms-button-text
                                          ms-button--text
                                          flex
                                          align-center
                                        "
                                      >
                                        <div class="line"></div>
                                        <div
                                          class="
                                            mi mi-16
                                            mi-arrow-up--white
                                            bg-green
                                          "
                                        >
                                          &nbsp;
                                        </div>
                                      </div>
                                    </button>
                                  </template>
                                  <template slot="dropdown-list">
                                    <div
                                      class="
                                        ms-component
                                        ms-dropdown-item-secondary-false
                                        ms-dropdown--item
                                      "
                                      @click="setButtonSaveAndAddNew()"
                                    >
                                      <a class="ms-dropdown--item-link"
                                        >Cất và Thêm
                                      </a>
                                    </div>
                                    <div
                                      class="
                                        ms-component
                                        ms-dropdown-item-secondary-false
                                        ms-dropdown--item
                                      "
                                      @click="setButtonSaveAndClose()"
                                    >
                                      <a class="ms-dropdown--item-link"
                                        >Cất và Đóng
                                      </a>
                                    </div>
                                    <div
                                      class="
                                        ms-component
                                        ms-dropdown-item-secondary-false
                                        ms-dropdown--item
                                      "
                                      @click="setButtonSaveAndPrint()"
                                    >
                                      <a class="ms-dropdown--item-link"
                                        >Cất và In
                                      </a>
                                    </div>
                                  </template>
                                </dropdown-button>
                              </div>
                            </div>

                            <button
                              class="
                                ms-component ms-button
                                first-right-button-footer
                                class-button-custom
                                ms-button-size-footer
                                ms-button-footer
                                ms-button-footer-disabled-false
                                ms-button-radius-false
                                ms-button
                              "
                              @click="savePayment()"
                            >
                              <div
                                class="
                                  ms-button-text
                                  ms-button--text
                                  flex
                                  align-center
                                "
                              >
                                Cất
                              </div>
                            </button>
                          </div>
                        </div>

                        <div class="flex flex-grow">
                          <div class="left-group-button">
                            <div class="inner-left-group-button flex">
                              <button
                                name="button"
                                class="
                                  ms-component ms-button
                                  m-r-6
                                  class-button-custom
                                  ms-button-size-footer
                                  ms-button-footer
                                  ms-button-footer-disabled-false
                                  ms-button-radius-false
                                  ms-button
                                "
                              >
                                <div
                                  class="
                                    ms-button-text
                                    ms-button--text
                                    flex
                                    align-center
                                  "
                                >
                                  Hủy
                                </div>
                              </button>
                            </div>
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>

    <!-- thông báo lỗi  -->
    <div class="con-ms-message-box" id="error-dialog">
      <div class="message-center">
        <div class="ms-message-bg"></div>
        <div class="drag-it-dude">
          <div class="ms-mesage-box">
            <div style="width: 444px; min-width: 444px">
              <div class="padding-32">
                <div class="content">
                  <div class="icon-message">
                    <div class="mi mi-48 mi-exclamation-error-48-2"></div>
                  </div>
                  <div class="message-content p-l-16 p-t-12">
                    <span id="idMessageError" class="message"></span>
                  </div>
                </div>
                <div class="mess-line"></div>
                <div class="mess-footer">
                  <div class="Center">
                    <button
                      name="button"
                      class="
                        ms-component
                        ms-button
                        ms-button-size-default
                        ms-button-primary
                        ms-button-primary-disabled-false
                        ms-button-radius-false
                        ms-button
                      "
                      @click="hideErrorDialog()"
                    >
                      <div
                        class="ms-button-text ms-button--text flex align-center"
                      >
                        Đóng
                      </div>
                    </button>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
var localhost = "https://localhost:44350/api/Payments/";
var localhostSupplier = "https://localhost:44350/api/Suppliers/";

import MsInput from "../baseControl/MsInput.vue";
import MsInputDate from "../baseControl/MsInputDate.vue";
import MsTextarea from "../baseControl/MsTextarea.vue";
import MsSelect from "../baseControl/MsSelect.vue";
import SelectAutoCompleteMenuTable from "../baseControl/SelectAutoCompleteMenuTable.vue";
import DropdownButton from "../baseControl/DropdownButton.vue";
import EventBus from "../../main.js";

import * as axios from "axios";
export default {
  components: {
    MsInput,
    MsInputDate,
    MsTextarea,
    MsSelect,
    SelectAutoCompleteMenuTable,
    DropdownButton,
  },
  props: {
    isShowPopup: {
      type: Boolean,
      default: false,
    },
    idPayment: {
      type: String,
      default: "",
    },
  },
  data() {
    return {
      isEdit: false,
      isReadOnly: false,
      mustValidate: false,
      inputFocus: "",
      startWatch: false,

      payment: {
        paymentobjectcode: "NV123",
        paymentobjectname: "",
        paymentaddress: "Hà nội",
        reasonpay: "Chi tiền cho",
        paymentemployeecode: "NV3610",
        numberoflicense: null,
        accountingdate: "",
        paymentdate: "",
        typeofmoney: "VND",
        totalmoney: "0",
        paymentnumber: "PC002",
        idpayment: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      },

      typeOfPayment: [
        "1. Tạm ứng cho nhân viên",
        "2. Gửi tiền vào ngân hàng",
        "3. Trả tiền nhà cung cấp (không theo hóa đơn)",
        "4. Chi mua ngoài có hóa đơn",
        "5. Chi khác",
      ],

      paymentMethods: ["Ủy nhiệm chi", "Séc chuyển khoản", "Séc tiền mặt"],

      colAccountPay: [
        { name: "Số tài khoản", width: "150" },
        { name: "Tên ngân hàng", width: "300" },
        { name: "Chi nhánh", width: "200" },
      ],

      accountPays: [
        {
          accountNumber: "66886688",
          accountName: "Ngân hàng chuyển đổi số",
          branch: "Hai Bà Trưng",
        },
        {
          accountNumber: "123456",
          accountName: "Ngân hàng quân đội",
          branch: "Duy Tân, Cầu Giấy",
        },
      ],

      colTheObject: [
        { name: "Đối tượng", width: "120" },
        { name: "Tên đối tượng", width: "250" },
        { name: "Mã số thuế", width: "100" },
        { name: "Địa chỉ", width: "300" },
        { name: "Điện thoại", width: "100" },
      ],
      theObjects: [],

      colAccountReceive: [
        { name: "Số tài khoản", width: "120" },
        { name: "Tên ngân hàng", width: "300" },
        { name: "Chi nhánh", width: "200" },
      ],
      accountReceives: [
        {
          accountNumber: "66886688",
          accountName: "Ngân hàng chuyển đổi số",
          branch: "Hai Bà Trưng",
        },
        {
          accountNumber: "123456",
          accountName: "Ngân hàng quân đội",
          branch: "Duy Tân, Cầu Giấy",
        },
      ],

      colEmployee: [
        { name: "Mã nhân viên", width: "120" },
        { name: "Tên nhân viên", width: "120" },
        { name: "Đơn vị", width: "120" },
        { name: "ĐT di dộng", width: "120" },
      ],
      employees: [
        {
          employeeCode: "NV3610",
          employeeName: "Nguyễn A",
          agencies: "Công ty cổ phần 789",
          phoneNumber: "0915612699",
        },
        {
          employeeCode: "NV132",
          employeeName: "Trần Chân",
          agencies: "Công ty cổ phần 789",
          phoneNumber: "0915612699",
        },
      ],

      colTypeOfMoney: [
        { name: "Mã loại tiền", width: "100" },
        { name: "Tên loại tiền", width: "200" },
      ],
      typeOfMoneys: [
        {
          moneyCode: "VND",
          moneyName: "Việt Nam Đồng",
        },
        {
          moneyCode: "USD",
          moneyName: "Đô la Mỹ",
        },
      ],

      colAccountDebt: [
        { name: "Số tài khoản", width: "120" },
        { name: "Tên tài khoản", width: "250" },
      ],
      accountDebt: [
        {
          accountNumber: "12345",
          accountName: "Tiền Việt",
        },
        {
          accountNumber: "1111",
          accountName: "Tiền Mỹ",
        },
      ],

      accounting: [
        {
          idaccounting: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
          idpayment: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
          description: "Chi tiền cho",
          accountdebtnumber: "12345",
          accountreceivenumber: "1111",
          money: null,
          objectcode: "",
          objectname: "",
        },
      ],

      exchangeRate: 1,

      //nút dưới footer
      isSaveAndAddNew: false,
      isSaveAndClose: true,
      isSaveAndPrint: false,
    };
  },
  computed: {
    reasonpay() {
      return this.payment.reasonpay;
    },
    paymentobjectcode() {
      return this.payment.paymentobjectcode;
    },
    typeofmoney() {
      return this.payment.typeofmoney;
    },
  },
  watch: {
    isShowPopup(newV) {
      if (newV) {
        var m = this;
        setTimeout(function () {
          if (m.idPayment) {
            m.startWatch = false;
            m.getPayment(m.idPayment);
          } else {
            m.resetInfoPaymnet();
          }
          m.mustValidate = false;
        }, 100);
      }
      // console.log(oldV);
    },
    reasonpay(newV, oldV) {
      if (this.startWatch) {
        this.changeReasonPayInGrid(newV, oldV);
      }
    },
    paymentobjectcode(newV, oldV) {
      if (this.startWatch) {
        this.fillInfo(newV, oldV);
      }
    },
    typeofmoney() {
      this.getExchangeRate();
    },
  },
  methods: {
    closePopup() {
      this.$emit("closePaymentPopup", false);
    },

    loadData() {
      this.$emit("loadData");
    },

    //xóa 1 dòng trong bảng hạch toán
    deleteRowAccounting(i) {
      this.accounting.splice(i, 1);
      this.sumMoney();
    },

    //thêm dòng bảng hạch toán
    addRowAccounting() {
      let newAccount = {};
      if (this.accounting.length == 0) {
        newAccount = {
          idaccounting: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
          idpayment: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
          description: "",
          accountdebtnumber: "12345",
          accountreceivenumber: "1111",
          money: null,
          objectcode: "",
          objectname: "",
        };
        newAccount.description = this.payment.reasonpay;
        
      } else {
        // newAccount = this.accounting[this.accounting.length - 1];
        newAccount = {
          idaccounting: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
          idpayment: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
          description: this.accounting[this.accounting.length - 1].description,
          accountdebtnumber:
            this.accounting[this.accounting.length - 1].accountdebtnumber,
          accountreceivenumber:
            this.accounting[this.accounting.length - 1].accountreceivenumber,
          money: null,
          objectcode: this.accounting[this.accounting.length - 1].objectcode,
          objectname: this.accounting[this.accounting.length - 1].objectname,
        };
      }
      this.accounting.push(newAccount);
      this.sumMoney();
    },

    //xóa tất cả dòng trong bảng hạch toán
    removeAllRowAccounting() {
      this.accounting = [];
      let newAccount = {
        idaccounting: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        idpayment: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        description: "Chi tiền cho",
        accountdebtnumber: "12345",
        accountreceivenumber: "1111",
        money: null,
        objectcode: "",
        objectname: "",
      };
      this.accounting.push(newAccount);
      this.sumMoney();
    },

    //Đổi kiểu cho button Cất
    setButtonSaveAndAddNew() {
      this.isSaveAndAddNew = true;
      this.isSaveAndClose = false;
      this.isSaveAndPrint = false;
    },
    setButtonSaveAndClose() {
      this.isSaveAndAddNew = false;
      this.isSaveAndClose = true;
      this.isSaveAndPrint = false;
    },
    setButtonSaveAndPrint() {
      this.isSaveAndAddNew = false;
      this.isSaveAndClose = false;
      this.isSaveAndPrint = true;
    },
    currentDate() {
      const current = new Date();
      const date = `${current.getDate()}/${
        current.getMonth() + 1
      }/${current.getFullYear()}`;
      return date;
    },

    //focus vào input
    focusInput(refInput) {
      this.$refs[refInput].focusInput();
    },

    //ẩn hiện thông báo lỗi
    showErrorDialog(content) {
      document.getElementById("idMessageError").innerHTML = content;
      document.getElementById("error-dialog").style.display = "block";
    },

    hideErrorDialog() {
      document.getElementById("error-dialog").style.display = "none";
      // document.getElementById(this.inputFocus).focus();
      this.focusInput(this.inputFocus);
    },

    //tính tổng tiền
    sumMoney() {
      // console.log("tính tổng");
      let sum = 0;
      for (let i = 0; i < this.accounting.length; i++) {
        // console.log(this.accounting[i].money);
        if (this.accounting[i].money) {
          sum += parseFloat(this.accounting[i].money);
        }
      }
      // console.log(sum);
      this.payment.totalmoney = sum;
    },

    //thay đổi diễn giải dưới phần hạch toán
    changeReasonPayInGrid(newReasonPay, oldReasonPay) {
      for (let i = 0; i < this.accounting.length; i++) {
        if (this.accounting[i].description != oldReasonPay) {
          continue;
        }
        this.accounting[i].description = this.payment.reasonpay;
      }
    },

    //tự điền thông tin  đối tượng
    async fillInfo(newObjectCode, oldObjectCode) {
      let m = this;
      await axios({
        method: "get",
        url: localhostSupplier + "supplierCode?supplierCode=" + newObjectCode,
      })
        .then(function (response) {
          //thành công
          // console.log(response.data);
          let object = response.data;
          if (object.typeofsupplier == "personal") {
            m.payment.paymentobjectname = object.suppliername;
          } else if (object.typeofsupplier == "organization") {
            m.payment.paymentobjectname = object.legalrepresentation;
          }
          m.payment.paymentaddress = object.supplieraddress;
          m.payment.reasonpay = "Chi tiền cho " + object.suppliername;

          for (let i = 0; i < m.accounting.length; i++) {
            // console.log(m.accounting[i].objectcode);
            // console.log(oldObjectCode);
            if (
              m.accounting[i].objectcode != oldObjectCode &&
              m.accounting[i].objectcode != ""
            ) {
              continue;
            }
            m.accounting[i].objectcode = object.suppliercode;
            m.accounting[i].objectname = object.suppliername;
          }
        })
        .catch(function (error) {
          //gặp lỗi
          console.log(error);
        });
    },

    //điền tên đối tượng hạch toán
    fillObjectName(objectCode, i) {
      let m = this;
      axios({
        method: "get",
        url: localhostSupplier + "supplierCode?supplierCode=" + objectCode,
      })
        .then(function (response) {
          //thành công
          // console.log(response.data);
          m.accounting[i].objectname = response.data.suppliername;
        })
        .catch(function (error) {
          //gặp lỗi
          console.log(error);
        });
    },

    //tỷ giá
    getExchangeRate() {
      switch (this.payment.typeofmoney) {
        case "VND":
          this.exchangeRate = 1;
          break;
        case "USD":
          this.exchangeRate = 23;
          break;
      }
    },

    //đổi định dạng ngày để push
    formatDateToPush(date) {
      if (!date) return null;

      let [day, month, year] = date.split("/");
      day++;
      let newDate = `${year}-${month}-${day}`;
      return new Date(newDate).toISOString();
    },

    //đổi định dạng ngày để hiển thị
    formatDateToShow(date) {
      if (!date) return "";

      date = new Date(date);
      let day = date.getDate();
      let month = date.getMonth() + 1;
      let year = date.getFullYear();
      return `${day}/${month}/${year}`;
    },

    //chuyển kiểu dd/mm/yyyy sang yyyy-mm-dd
    parseDate(date) {
      if (!date) return "";
      // console.log(date);
      let [day, month, year] = date.split("/");

      return `${year}-${month.padStart(2, "0")}-${day.padStart(2, "0")}`;
    },
    //so sánh ngày hạch toán phải lớn hơn ngày phiếu chi
    validateAccountingDate() {
      let accountingDate = this.parseDate(this.payment.accountingdate);
      let paymentDate = this.parseDate(this.payment.paymentdate);
      if (
        new Date(accountingDate).getTime() - new Date(paymentDate).getTime() >=
        0
      ) {
        return true;
      } else {
        return false;
      }
    },

    //validate
    checkInfoPayment() {
      if (this.payment.paymentnumber.trim() == "") {
        this.showErrorDialog("Số phiếu chi không được để trống");
        this.mustValidate = true;
        this.inputFocus = "inputPaymentNumber";
        return false;
      } else if (!this.validateAccountingDate()) {
        this.showErrorDialog("Ngày hạch toán phải lớn hơn ngày phiếu chi");
        this.mustValidate = true;
        this.inputFocus = "inputAccountingDate";
        return false;
      } else {
        return true;
      }
    },

    async getObjectSupplier() {
      //lấy dữ liệu vào select đối tượng
      const response = await axios.get(localhostSupplier);
      let objects = response.data;
      this.theObjects = [];
      for (let i = 0; i < objects.length; i++) {
        let obj = {};
        obj.objectCode = objects[i].suppliercode;
        obj.objectName = objects[i].suppliername;
        obj.taxCode = objects[i].suppliertaxcode;
        obj.address = objects[i].supplieraddress;
        obj.phone = objects[i].supplierphone;

        this.theObjects.push(obj);
      }
    },

    //reset thông tin payment
    async resetInfoPaymnet() {
      this.mustValidate = false;
      this.inputFocus = "";
      this.startWatch = true;

      this.getObjectSupplier();

      //reset payment và lấy mã mới
      this.payment = {
        paymentobjectcode: "",
        paymentobjectname: "",
        paymentaddress: "",
        reasonpay: "Chi tiền cho",
        paymentemployeecode: "",
        numberoflicense: null,
        accountingdate: "",
        paymentdate: "",
        typeofmoney: "VND",
        totalmoney: "0",
        paymentnumber: "",
        idpayment: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      };

      this.removeAllRowAccounting();

      let m = this;
      axios({
        method: "get",
        url: localhost + "newpaymentnumber",
      })
        .then(function (response) {
          //thành công
          console.log(response.data);
          m.payment.paymentnumber = response.data;
        })
        .catch(function (error) {
          //gặp lỗi
          console.log(error);
        });

      //set ngày hạch toán và ngày phiếu chi
      this.payment.accountingdate = this.currentDate();
      this.payment.paymentdate = this.currentDate();

      this.isEdit = false;
    },

    //lấy thông tin phiếu chi
    getPayment(id) {
      let m = this;
      axios({
        method: "get",
        url: localhost + id,
      })
        .then(function (response) {
          //thành công
          console.log(response.data);
          m.payment = response.data;
          m.payment.accountingdate = m.formatDateToShow(
            response.data.accountingdate
          );
          m.payment.paymentdate = m.formatDateToShow(response.data.paymentdate);

          m.accounting = response.data.accoutings;
        })
        .catch(function (error) {
          //gặp lỗi
          console.log(error);
        });
    },

    //ấn cất hoặc cất và đóng
    savePayment() {
      if (this.checkInfoPayment()) {
        if (this.isEdit) {
          this.editPayment();
        } else {
          this.addPayment();
        }
      }
    },

    editPayment() {},

    addPayment() {
      let newPayment = {};
      newPayment = Object.assign(newPayment, this.payment);
      newPayment.accountingdate = this.formatDateToPush(
        this.payment.accountingdate
      );
      newPayment.paymentdate = this.formatDateToPush(this.payment.paymentdate);
      newPayment.accoutings = this.accounting;
      console.log(newPayment);

      var m = this;
      axios({
        method: "post",
        url: localhost,
        data: newPayment,
      })
        .then(function (response) {
          //thành công
          console.log(response);
          m.resetInfoPaymnet();
          m.closePopup();
          m.loadData();
        })
        .catch(function (error) {
          //gặp lỗi
          var noti = error.response.data;
          m.showErrorDialog(noti.userMsg);
          if (noti.errorCode == "misa-001") {
            m.inputFocus = "inputPaymentNumber";
          }
        });
    },
  },

  created() {
    this.getObjectSupplier();

    this.payment.accountingdate = this.currentDate();
    this.payment.paymentdate = this.currentDate();
    EventBus.$on("setIsEdit", (data) => (this.isEdit = data));
    EventBus.$on("setIsReadOnly", (data) => (this.isReadOnly = data));
  },
};
</script>

<style>
.header-layout-wrap {
  background: #fff;
}

.base-view-detail {
  display: flex;
  flex-direction: column;
  background: #fff;
  height: 100vh;
  width: 100%;
}

.base-view-detail .header {
  top: 0;
  width: 100%;
  background-color: #f4f5f8;
}

.base-view-detail .header .top-header {
  padding: 9px 16px;
  display: flex;
  margin-bottom: 7px;
}

.recent-log-btn {
  display: flex;
}

.base-view-detail .header .title {
  font-weight: 700;
  font-size: 24px !important;
  top: -7px;
  left: 20px;
  padding: 0 0 0 16px;
  color: #111;
  white-space: nowrap;
  overflow: hidden;
  text-overflow: ellipsis;
}

.base-view-detail .header .header-detail-input {
  display: flex;
  justify-content: left;
  align-items: center;
  padding-left: 50px;
  flex: 1;
  min-width: 600px;
}

.base-view-detail .header .header-detail-input .combo-editor {
  margin-right: 12px;
  min-width: 100px;
  width: 300px;
}

.inline-label {
  margin-right: 10px;
  white-space: nowrap;
}

.combo-header {
  display: flex;
  align-items: center;
}

.header-detail-input
  .v-text-field.v-text-field--enclosed:not(.v-text-field--rounded)
  > .v-input__control
  > .v-input__slot {
  background: #fff;
}

.header-detail-input .v-text-field--outlined fieldset {
  bottom: 0;
  top: -7px;
}

.header-detail-input .v-text-field .v-input__append-inner {
  margin-top: 0px;
  cursor: pointer;
  height: 100%;
}

.top-header .header-detail-buttons .guide-tour {
  display: flex;
  margin: 0 12px;
}

.top-header .header-detail-buttons .con-ms-btn-header {
  height: 100%;
}

.top-header .header-detail-buttons .con-ms-btn-header .header-detail-btn {
  padding: 6px 8px;
  cursor: pointer;
  height: 100%;
  display: flex;
  align-items: center;
}

/* BODY  */
.base-view-detail .body {
  flex: 1;
  min-height: 0;
  min-width: 0;
  overflow: auto;
  position: relative;
  scroll-behavior: smooth;
}

.bgr-main-information {
  background-color: #f4f5f8;
}

.bgr-main-information .main-information {
  padding-top: 16px !important;
}

.main-information {
  padding: 7px 30px 24px;
}

.bgr-main-information .main-information .inner-basic-information {
  padding: 0;
  margin-top: 0;
}

.row-input {
  padding-bottom: 12px;
  align-items: flex-end;
}

.root-invoice {
  padding-top: 28px;
  white-space: nowrap;
}

.reference {
  padding: 0 !important;
  height: 32px;
}

.ms-reference {
  display: flex;
  position: relative;
  align-items: center;
  width: -webkit-fit-content;
  width: -moz-fit-content;
  width: fit-content;
}

.ms-reference .reference-title {
  margin-right: 16px;
  min-width: 75px;
}

.ms-reference .ms-reference-show-more {
  cursor: pointer;
  color: #0075c0;
  font-weight: 700;
  white-space: nowrap;
  overflow: hidden;
  font-size: 12px;
}

.row-input-right {
  width: 185px;
  padding-bottom: 12px;
  align-items: flex-end;
  padding-left: 16px;
  border-left: 1px solid rgb(212, 215, 220);
}

/**cột tổng tiền bên phải */
.summary-info {
  text-align: right;
}

.summary-info .summary-info-title {
  font-size: 13px;
}

.summary-info .summary-info-number {
  font-size: 36px;
  font-weight: 700;
}

/**Bảng hạch toán */
.grid-tab {
  background: #fff;
  width: 100%;
  position: relative;
}

.grid-tab .tab-grid {
  display: inline-block;
}

.grid-tab .tab-grid {
  display: inline-block;
}
.ms-tabs-position-top {
  width: auto;
  overflow: visible;
}
.con-ms-tabs .con-ms-ul-tabs,
.con-ms-tabs {
  position: relative;
}

.con-ms-tabs .tab-detail {
  padding: 18px 0 18px 19px;
  position: sticky;
  width: 100vw;
  left: 0;
  display: flex;
}

.con-ms-tabs .tab-detail {
  width: calc(100vw - 10px);
}

.con-ms-tabs .tab-detail .ms-tabs-ul {
  flex: 1;
}

.con-ms-tabs .con-ms-ul-tabs .ms-tabs-ul {
  margin: 0;
  width: 100%;
  height: 100%;
  padding-left: 0;
  position: relative;
  display: flex;
}
.con-ms-tabs .tab-detail ul {
  margin: 0;
}

.con-ms-tabs .con-ms-ul-tabs .ms-tabs-ul .ms-tabs-li {
  position: relative;
}

.con-ms-tabs .tab-detail .ms-tabs-ul .ms-tabs-li .ms-tabs-btn {
  margin: 0;
  padding: 0 16px;
  color: #0075c0 !important;
}

.con-ms-tabs .con-ms-ul-tabs .ms-tabs-ul .ms-tabs-li .ms-tabs-btn {
  position: relative;
  width: 100%;
  background: transparent;
  border: 0;
  border-radius: 30px;
  cursor: pointer;
  transition: all 0.2s ease;
  z-index: 0;
  font-size: 13px;
}

.con-ms-tabs .tab-detail .ms-tabs-ul .active-item .tab-label {
  color: #0075c0;
  font-weight: 700;
  text-decoration: underline;
}

.con-ms-tabs
  .tab-detail
  .ms-tabs-ul
  .active-item
  .tab-label:hover:not(:disabled) {
  background: none;
  color: #2ca01c;
}

.con-ms-tabs .con-ms-ul-tabs .ms-tabs-ul .ms-tabs-li:focus:not(:disabled) {
  outline: none;
}

.ms-label {
  text-align: center;
  white-space: nowrap;
  font-size: 13px;
}

.grid-tab .grid-option {
  position: absolute;
  right: 30px;
  top: 12px;
  align-items: center;
  justify-content: flex-end;
}

.grid-tab .grid-option .label-option {
  padding-right: 10px;
  white-space: nowrap;
  padding-left: 20px;
}

.grid-tab .grid-option .currency-combobox {
  max-width: 100px;
  width: 100px;
}

.cls-width-exchange-rate {
  width: 90px;
}

.ms-tabs-position-top .con-slot-tabs {
  position: relative;
  display: block;
  overflow: visible;
}

.con-ms-tabs .con-slot-tabs .ms-tabs--content {
  position: relative;
  width: 100%;
  display: block;
}

.grid-detail-data {
  padding: 0;
}

.gridComponent {
  position: relative;
  min-width: 100%;
}

/**Footer */
.footer-container {
  z-index: 10;
}

.footer .footer-button-group,
.footer {
  width: 100%;
  background-color: #38393d;
  display: flex;
  align-items: center;
}

.footer .footer-button-group {
  padding: 8px 16px;
  position: relative;
}

.footer .footer-button-group .right-group-button {
  text-align: right;
  justify-content: flex-end;
  z-index: 1;
}

.ms-button-size-footer {
  height: 34px;
  padding: 6px 20px;
}

.footer-button-group .ms-button-primary {
  background-color: #35bf22;
}

.ms-radius-false,
.ms-radius-false:before {
  border-radius: 3px 0 0 3px;
}

.ms-dropdown-style-footer {
  height: 34px;
  padding: 6px 14px 6px 20px;
}

.footer-button-group .ms-button-primary {
  background-color: #35bf22;
}

.ms-con-dropdown-radius-false-false,
.ms-con-dropdown-radius-false-false:before {
  border-radius: 0 3px 3px 0;
}

.ms-padding-is-single-false-size-footer {
  height: 34px;
  padding: 6px 16px 6px 8px;
}

.footer .footer-button-group .right-group-button .first-right-button-footer {
  margin-right: 5px;
}

.ms-button-footer {
  border: 1px solid #6b6c72;
  color: #fff;
  background-color: transparent;
  position: relative;
}

.footer .footer-button-group .left-group-button {
  z-index: 10;
}
</style>

<style scoped>
/**bảng */
.dynamic-table {
  flex: 1;
}

.table-scroll {
  overflow: auto;
  margin-top: 0;
}
.table-scroll,
.table-scroll table {
  min-width: 100%;
}

.table-scroll table {
  margin: auto;
  border-spacing: 0;
  border-collapse: separate;
}

.table-scroll thead th {
  border-left: 1px solid #c7c7c7;
  border-bottom: 2px solid #c7c7c7;
  font-size: 12px;
}

.table-scroll td:first-child,
.table-scroll th:first-child {
  border-left: 0 !important;
}

.table-scroll thead tr th {
  padding: 4px;
  z-index: 1;
}

.table-scroll thead tr th {
  text-transform: uppercase;
}

.table-scroll th {
  min-height: 34px;
}

.table-scroll thead tr:first-child th.check-multiple-columns {
  position: sticky;
  max-width: 40px;
  width: 40px;
  min-width: 40px;
  z-index: 25;
  border-left: none;
}

.table-scroll thead tr:first-child th {
  background: #eceef1;
  top: 0;
  z-index: 20;
  position: relative;
}

.table-scroll thead tr:first-child th.dynamic-header {
  z-index: 20;
  position: sticky;
}

.th-height {
  height: inherit;
  padding: 8px 0;
  align-items: center;
}

.padding-th {
  padding: 0 20px 0 10px;
}

.th-table {
  display: flex;
  align-items: center;
  text-transform: uppercase !important;
}

.th-table span {
  text-transform: uppercase !important;
  flex: 1;
  min-height: 0;
  min-width: 0;
}

.dis-contents {
  display: contents;
}

.table-scroll tbody tr {
  font-size: 13px;
}

.table-scroll th,
.table-scroll tr td {
  background-color: #fff;
  padding: 0 10px;
  border-bottom: 1.2px solid #c7c7c7;
  border-left: 1px dotted #c7c7c7;
}

.table-scroll tr td {
  height: 40px;
  position: relative;
}

.wiget.wiget-title {
  z-index: 25 !important;
}

.table-scroll tr td.ms-grid-row-number {
  position: sticky;
  z-index: 5;
  left: 30px;
}

.stt-cell {
  line-height: 2px;
}

.editable {
  min-height: 30px;
  position: relative;
}

.table-scroll tfoot,
.table-scroll tfoot td,
.table-scroll tfoot th {
  position: sticky;
  bottom: 0;
  background: #f8f9fe;
  padding: 4px 8px;
  border-top: 2px solid #c7c7c7;
  border-right: 0;
  border-left: 0;
  border-bottom: 0;
  font-size: 13px;
  z-index: 15;
}

.table-scroll th.ms-grid-row-number {
  left: 30px;
}

tfoot th {
  border-color: transparent !important;
  padding-right: 9px !important;
}

.grid-control-item {
  width: 100%;
  padding: 0 30px;
  background-color: #fff;
  position: sticky;
  left: 0;
}

.grid-control-item .btn-grid-control {
  padding-top: 10px;
  padding-bottom: 32px;
}

.grid-control-item .btn-grid-control button {
  padding: 2px 20px;
  margin-right: 10px;
  border-color: #8d9096;
  border-radius: 2.5px;
}

.ms-button-size-small {
  height: 24px;
  padding: 1px 20px 3px;
}

.ms-button-secondary:hover {
  background-color: #d2d3d6;
}
/**hết bảng */

.ms-upload {
  width: -webkit-fit-content;
  width: -moz-fit-content;
  width: fit-content;
  position: relative;
  width: 100%;
  font-size: 12px;
}

.ms-upload .ms-title-upload {
  margin-bottom: 6px;
  width: -webkit-fit-content;
  width: -moz-fit-content;
  width: fit-content;
  color: #111;
  display: flex;
}

.ms-upload .ms-title-upload .attach-text {
  display: flex;
  white-space: nowrap;
  font-weight: 700;
}

.ms-upload .ms-title-upload .max-size-upload {
  margin-left: 15px;
  color: #757575;
  white-space: nowrap;
}

.ms-upload .ms-img-upload {
  width: -webkit-fit-content;
  width: -moz-fit-content;
  width: fit-content;
  background: #fff;
  position: relative;
  box-sizing: border-box;
  overflow: hidden;
  width: 100%;
}

.ms-upload .ms-input-upload {
  background: #fff;
  padding: 16px 20px;
  box-sizing: border-box;
  border-radius: 2px;
  position: relative;
  border: 1px solid #babec5;
  display: flex;
  align-items: center;
  justify-content: center;
  flex-direction: column;
  float: left;
  width: 100%;
}

.ms-upload .ms-input-upload input {
  position: absolute;
  width: 100%;
  height: 100%;
  opacity: 0;
  left: 0;
  top: 0;
  cursor: pointer;
}

.ms-upload .ms-input-upload .text-input {
  min-width: 264px;
  display: block;
  text-align: center;
  margin: 0 !important;
  padding: 0 !important;
  width: 100%;
  color: #9e9e9e;
  font-style: italic;
}

.clear {
  height: 26px;
  width: 100%;
}
</style>