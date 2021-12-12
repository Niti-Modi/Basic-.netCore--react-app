import React, { useEffect, useState } from "react";
import { connect } from "react-redux";
import * as actions from "../actions/dCandidate";
import {
  Grid,
  Paper,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  withStyles,
  ButtonGroup,
  Button,
} from "@material-ui/core";
import DCandidateForm from "./DCandidateForm";
import EditIcon from "@material-ui/icons/Edit";
import DeleteIcon from "@material-ui/icons/Delete";
import { AddPhotoAlternateSharp } from "@material-ui/icons";
import { useToasts } from "react-toast-notifications";

//list of records

function styles(theme) {
  return {
    root: {
      "& .MuiTableCell-head": {
        fontSize: "1.25rem",
      },
    },

    paper: {
      margin: theme.spacing(2),
      padding: theme.spacing(2),
    },
  };
}

const DCandidates = ({ classes, ...props }) => {
  const [currentId, setCurrentId] = useState(0);

  useEffect(() => {
    props.fetchAllDCandidates();
  }, []);

  const { addToast } = useToasts();

  const onDelete = (id) => {
    if (window.confirm("Are you sure to delete this record?"));
    props.deleteDCandidates(id, () =>
      addToast(" deleted successfully", { appearance: "success" })
    );
  };

  return (
    <Paper className={classes.paper} elevation={3}>
      <Grid container>
        <Grid item xs={6}>
          <DCandidateForm {...{ currentId, setCurrentId }} />
        </Grid>
        <Grid item xs={6}>
          <div>
            <TableContainer>
              <Table>
                <TableHead className={classes.root}>
                  <TableRow>
                    <TableCell>Name</TableCell>
                    <TableCell>Mobile</TableCell>
                    <TableCell>Blood Group</TableCell>
                    <TableCell>-</TableCell>
                  </TableRow>
                </TableHead>
                <TableBody>
                  {props.dCandidateList.map((record, index) => {
                    return (
                      <TableRow key={index} hover>
                        <TableCell>{record.fullname}</TableCell>
                        <TableCell>{record.mobile}</TableCell>
                        <TableCell>{record.bloodGroup}</TableCell>
                        <TableCell>
                          <ButtonGroup variant="text">
                            <Button>
                              <EditIcon
                                color="primary"
                                onClick={() => {
                                  setCurrentId(record.id);
                                  console.log(currentId);
                                }}
                              />
                            </Button>
                            <Button>
                              <DeleteIcon
                                color="secondary"
                                onClick={() => onDelete(record.id)}
                              />
                            </Button>
                          </ButtonGroup>
                        </TableCell>
                      </TableRow>
                    );
                  })}
                </TableBody>
              </Table>
            </TableContainer>
          </div>
        </Grid>
      </Grid>
    </Paper>
  );
};

const mapStateToProps = (state) => {
  return {
    dCandidateList: state.dCandidate.list,
  };
};

const mapActionToProps = {
  fetchAllDCandidates: actions.fetchAll,
  deleteDCandidates: actions.Delete,
};

export default connect(
  mapStateToProps,
  mapActionToProps
)(withStyles(styles)(DCandidates));
