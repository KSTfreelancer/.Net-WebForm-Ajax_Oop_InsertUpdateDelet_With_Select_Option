<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentUI.aspx.cs" Inherits="Ajax_OOP.UI.StudentUI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
    <style>
        input[type=number]::-webkit-inner-spin-button,
        input[type=number]::-webkit-outer-spin-button {
            /*opacity: 0;*/
            display: none;
        }

        .card.pp  {
            max-height: 270px;
            overflow: hidden;
        }
       .card.pp thead {
    position: sticky;
    top: 0;
}

     
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="text-center text-success ">
        <h5>Student Page</h5>
    </div>

    <div class="card">
        <div class="card-header bg-secondary text-center fw-bold text-light">Student Entry/Removed</div>
        <div class="card-body">
            <div class="row fw-bold text-secondary">
                <div class="col-md-4 mb-3 ">
                    <label for="name" class="form-label">Student Name:</label>
                    <input type="text" class="form-control" id="name" placeholder="Enter Student Name" name="name">
                </div>

                <div class="col-md-8">
                    <div class="row">
                        <div class="col-md-4 mb-3 ">
                            <label for="roll" class="form-label">Student Roll:</label>
                            <input type="number" class="form-control" id="roll" placeholder="Enter Student Roll" name="roll">
                        </div>
                        <div class="col-md-4 mb-3 ">
                            <label for="reg" class="form-label">Student RegNo:</label>
                            <input type="number" class="form-control" id="reg" placeholder="Enter Student RegNo" name="reg">
                        </div>
                        <div class="col-md-4 mb-3 ">
                            <label for="dpt" class="form-label">Department:</label>
                           <%-- <input type="text" class="form-control" id="dpt" placeholder="Enter Department" name="dpt">--%>
                            <select class="form-select" id="dpt" onchange="SubjecttShow(0)" >
                                <%--------------------%>
                            </select>
                        </div>
                    </div>
                </div>
                <div class="col-md-3 mb-3 ">
                    <label for="sub" class="form-label">Subject:</label>
                   <%-- <input type="text" class="form-control" id="sub" placeholder="Enter Subject" name="sub">--%>
                    <select class="form-select" id="sub"  >
                        <option value='-1'>--Select Subject--</option>
                                <%--------------------%>
                            </select>
                </div>
                <div class="col-md-9 mb-3 ">
                    <div class="row">
                        <div class="col-md-3 ">
                            <label for="semister" class="form-label">Semister:</label>
                            <select class="form-select" id="semisterShow"  >
                                <%--------------------%>
                            </select>
                        </div>
                        <div class="col-md-3 ">
                            <label for="sift" class="form-label">Shift:</label>
                            <select class="form-select" id="sift">
                                <option value="-1">Select Shift</option>
                                <option>1st</option>
                                <option>2nd</option>
                            </select>
                        </div>
                        <div class="col-md-3 ">
                            <label for="admission" class="form-label">Admission:</label>
                            <input type="date" class="form-control" id="admission" placeholder="Enter Admission" name="admission">
                        </div>
                        <div class="col-md-3 ">
                            <label for="farewell" class="form-label">Farewell:</label>
                            <input type="date" class="form-control" id="farewell" placeholder="Enter Farewell " name="farewell">
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="card-footer text-center">
            <button onclick="InsertStudent()" type="button" id="insert" class="btn btn-primary ms-1 me-1">Insert</button>
            <button onclick="UpdateStudent()" type="button" id="update" class="btn btn-info ms-1 me-1">Update</button>
            <button onclick="DeleteStudent()" type="button" id="delete" class="btn btn-danger ms-1 me-1">Delete</button>
            <button onclick="clrarInput()" type="button" class="btn btn-outline-success ms-1 me-1">Clear</button>
        </div>
    </div>
    <hr />
    <%-----------------------Tabel-----------------------------%>
    <div class="card pp">
        <div class="card-header bg-secondary text-center fw-bold text-light">Student Alldata</div>
        <div class="card-body p-0 table-responsive">
            <table class="table table-bordered table-responsive">
                <thead id="tabelHeadGenerate" class="bg-info text-center">
                    <tr>
                        <th>SL</th>
                        <th>Student Neme</th>
                        <th>Roll</th>
                        <th>RegNo</th>
                        <th>Department</th>
                        <th>Subject</th>
                        <th>Semister</th>
                        <th>Shift</th>
                        <th>Admission</th>
                        <th>Farewell</th>
                        <th>Option</th>
                    </tr>
                </thead>
                <tbody id="tabelBodyGenerate">
                </tbody>

                    
               
            </table>

             
        </div>
    </div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
    <script src="../js/StudentAjax.js"></script>
</asp:Content>
